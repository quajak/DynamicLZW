using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicLZW
{
    //Based on http://warp.povusers.org/EfficientLZW/part5.html
    public class LZWDecoder
    {
        public static byte[] Decode(byte[] data, int maxKeySize, int dictionarySize = 256, int offset = 0)
        {
            if(maxKeySize > 16)
            {
                throw new ArgumentOutOfRangeException();
            }
            List<byte> output = new List<byte>();
            BinaryStream input = new BinaryStream(data);
            Dictionary<ushort, byte[]> dictionary = new Dictionary<ushort, byte[]>();
            ushort dictPos = 0;
            // Initialize the dictionary
            for (ushort i = 0; i < dictionarySize; i++)
            {
                dictionary[dictPos++] = new byte[1] { (byte)(i + offset) };
            }

            //int indexSize = 9;
            int indexSize = 5;
            byte[] indexArr;
            if(maxKeySize > 8)
            {
                indexArr = new byte[maxKeySize / 8];
            }
            else
            {
                indexArr = new byte[1];
            }
            input.Read(indexArr, 0, indexSize);
            ushort indexVal = maxKeySize > 8 ? BitConverter.ToUInt16(indexArr) : (ushort)indexArr[0];
            output.AddRange(dictionary[indexVal]);
            byte[] oldValue = dictionary[indexVal];
            while (input.CanRead)
            {
                input.Read(indexArr, 0, indexSize);
                indexVal = maxKeySize > 8 ? BitConverter.ToUInt16(indexArr) : (ushort)indexArr[0];
                if (dictionary.ContainsKey(indexVal))
                {
                    output.AddRange(dictionary[indexVal]);
                    var B = dictionary[indexVal][0];
                    dictionary[dictPos++] = Combine(oldValue, B);
                }
                else
                {
                    var B = oldValue[0];
                    dictionary[dictPos] = Combine(oldValue, B);
                    output.AddRange(dictionary[dictPos]);
                    dictPos++;
                }
                oldValue = dictionary[indexVal];
                if(dictPos > (1 << indexSize) - 1)
                {
                    indexSize++;
                    if(indexSize > maxKeySize)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            return output.ToArray();
        }

        private static byte[] Combine(byte[] a, byte b)
        {
            byte[] c = new byte[a.Length + 1];
            Array.Copy(a, c, a.Length);
            c[a.Length] = b;
            return c;
        }
    }
}
