using NUnit.Framework;
using DynamicLZW;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicLZW.Tests
{
    [TestFixture()]
    public class BinaryStreamTests
    {
        [Test()]
        public void BinaryStreamTest()
        {
            byte[] data = new byte[] { 0x1, 0x2, 0x3 };
            BinaryStream binaryStream = new BinaryStream(data);
            Assert.AreEqual(24, binaryStream.Length);
            Assert.AreEqual(0, binaryStream.Position);
            Assert.IsTrue(binaryStream.CanRead);
            Assert.IsTrue(binaryStream.CanSeek);
            Assert.IsFalse(binaryStream.CanWrite);
        }

         [Test()]
         public void TestSimpleRead()
        {
            byte[] data = new byte[] { 0b10101111, 0b00001100 };
            var binaryStream = new BinaryStream(data);
            byte[] output = new byte[1];
            binaryStream.Read(output, 0, 4);
            Assert.AreEqual(0b1010, output[0]);
            binaryStream.Read(output, 0, 4);
            Assert.AreEqual(0b1111, output[0]);
            binaryStream.Read(output, 0, 3);
            Assert.AreEqual(0, output[0]);
            binaryStream.Read(output, 0, 5);
            Assert.AreEqual(0b1100, output[0]);
        }

        [Test()]
        public void TestLongRead()
        {
            byte[] data = new byte[] { 0b10101111, 0b10110011 };
            var binaryStream = new BinaryStream(data);
            byte[] output = new byte[2];
            binaryStream.Read(output, 0, 14);
            Assert.AreEqual(0b101011, output[0]);
            Assert.AreEqual(0b11101100, output[1]);
        }

        [Test()]
        public void TestFullRead()
        {
            byte[] data = new byte[] { 0b10101111, 0b10110011 };
            var binaryStream = new BinaryStream(data);
            byte[] output = new byte[2];
            binaryStream.Read(output, 0, 16);
            Assert.AreEqual(0b10101111, output[0]);
            Assert.AreEqual(0b10110011, output[1]);
        }

    }
}