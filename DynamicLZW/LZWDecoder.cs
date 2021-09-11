using System;
using System.Collections.Generic;

namespace DynamicLZW
{
    //Based on http://warp.povusers.org/EfficientLZW/part5.html
    public class LZWDecoder
    {
        public static byte[] Decode(byte[] data, int maxKeySize, int dictionarySize = 256, int offset = 0, int indexSize = 8)
        {
            if (maxKeySize > 16)
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

            byte[] indexArr;
            if (maxKeySize > 8)
            {
                indexArr = new byte[maxKeySize / 8];
            }
            else
            {
                indexArr = new byte[1];
            }
            ushort indexVal;
            byte[] oldValue = new byte[0];
            while (input.CanRead && input.Length - input.Position >= indexSize)
            {
                input.Read(indexArr, 0, indexSize);
                indexVal = ToValue(indexArr, indexSize);
                if (dictionary.ContainsKey(indexVal))
                {
                    output.AddRange(dictionary[indexVal]);
                    if (oldValue.Length != 0)
                    {
                        var B = dictionary[indexVal][0];
                        dictionary[dictPos++] = Combine(oldValue, B);
                    }
                }
                else
                {
                    var B = oldValue[0];
                    dictionary[dictPos] = Combine(oldValue, B);
                    output.AddRange(dictionary[dictPos]);
                    dictPos++;
                }
                oldValue = dictionary[indexVal];
                if (dictPos > (1 << indexSize) - 1)
                {
                    indexSize++;
                    if (indexSize > maxKeySize)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            return output.ToArray();
        }

        private static ushort ToValue(byte[] aArray, int indexSize)
        {
            if (aArray.Length == 1 || indexSize <= 8)
            {
                return aArray[0];
            }
            else
            {
                return (ushort)((aArray[0] << 8) + aArray[1]);
            }
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
