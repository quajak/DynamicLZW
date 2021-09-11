using NUnit.Framework;

namespace DynamicLZW.Tests
{
    [TestFixture()]
    public class LZWDecoderTests
    {
        [Test()]
        public void WikipediaExampleDecodeTest()
        {
            byte[] message = new byte[] { 0b10100011, 0b11000100, 0b01010111, 0b11001000, 0b11100011, 0b11010100, 0b01101101, 0b11010111, 0b11100100, 0b01111010, 0b00001000, 0b10000000 };
            byte[] output = LZWDecoder.Decode(message, 6, 27, 64);
            string outp = "";
            for (int i = 0; i < output.Length; i++)
            {
                outp += (char)output[i];
            }
            Assert.AreEqual("TOBEORNOTTOBEORTOBEORNOT@", outp);
        }
    }
}