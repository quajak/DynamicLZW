﻿using NUnit.Framework;

namespace DynamicLZW.Tests
{
    [TestFixture()]
    public class LZWDecoderTests
    {
        [Test()]
        public void WikipediaExampleDecodeTest()
        {
            byte[] message = new byte[] { 0b10100011, 0b11000100, 0b01010111, 0b11001000, 0b11100011, 0b11010100, 0b01101101, 0b11010111, 0b11100100, 0b01111010, 0b00001000, 0b10000000 };
            byte[] output = LZWDecoder.Decode(message, 6, 27, 64, 5);
            string outp = "";
            for (int i = 0; i < output.Length; i++)
            {
                outp += (char)output[i];
            }
            Assert.AreEqual("TOBEORNOTTOBEORTOBEORNOT@", outp);
        }

        [Test()]
        public void TextDecodeTest()
        {
            // Generated using https://planetcalc.com/9069/
            byte[] message = new byte[] { 0b01000001, 0b00010000, 0b00011100, 0b10001101, 0b11100110, 0b00100011, 0b01111001, 0b11010000, 0b01000000, 0b01101101, 0b00110000, 0b10011110, 0b01000100, 0b00000110, 0b11101000, 0b00101000, 0b10000000, 0b11010010, 0b01101110, 0b00110101, 0b00011101, 0b01001110, 0b01000110, 0b01010001, 0b00000001, 0b10000100, 0b01000000, 0b01101000, 0b00111010, 0b11000010, 0b00001101, 0b11000010, 0b00000011, 0b00010001, 0b10010110, 0b00011110, 0b01100111, 0b00010000, 0b00011011, 0b11001110, 0b01000010, 0b11000001, 0b00000001, 0b11010000, 0b11010001, 0b00000010, 0b00111010, 0b10011001, 0b11001101, 0b00010000, 0b11100011, 0b01110001, 0b10000100, 0b11000110, 0b01110100, 0b00110100, 0b10011011, 0b11001101, 0b11010010, 0b01000011, 0b00001001, 0b10110000, 0b11011000, 0b01101111, 0b00111011, 0b11000101, 0b01100010, 0b11110001, 0b10010011, 0b00001100, 0b01101110, 0b00111011, 0b00011111, 0b10010010, 0b10011011, 0b11000100, 0b00000110, 0b00110011, 0b01111001, 0b10110110, 0b00101000, 0b01110100, 0b10100001, 0b00011010, 0b00001100, 0b00100111, 0b00100011, 0b01101000, 0b10111000, 0b01000001, 0b00000000, 0b10000001, 0b01000001, 0b00100000, 0b11000110, 0b11010011, 0b10101001, 0b11001110, 0b00001101, 0b00000011, 0b00110010, 0b11000010, 0b10100100, 0b11010001, 0b01001001, 0b00010001, 0b10010000, 0b11001010, 0b01110010, 0b00111001, 0b10001000, 0b00001100, 0b11100110, 0b10010011, 0b10110001, 0b10010110, 0b00110111, 0b01001000, 0b10000111, 0b01000001, 0b10001100, 0b01010000, 0b10101000, 0b11000100, 0b01101010, 0b00111001, 0b00011110, 0b00110111, 0b00011001, 0b11001110, 0b01110010, 0b01000011, 0b00101001, 0b11100000, 0b11000110, 0b01100101, 0b00111000, 0b01000001, 0b10001110, 0b11100110, 0b10001010, 0b11111100, 0b01010000, 0b11100110, 0b01110101, 0b00110001, 0b11001010, 0b11101011, 0b10110101, 0b11111011, 0b00001001, 0b11011100, 0b11011110, 0b01110101, 0b00110110, 0b00011001, 0b00101000, 0b01110011, 0b00100011, 0b00110001, 0b10110000, 0b11010011, 0b00101111, 0b00010000, 0b00011101, 0b11001101, 0b00110010, 0b01101001, 0b00101101, 0b11110000, 0b01000000, 0b01000110, 0b00110100, 0b11011000, 0b00100000, 0b11000100, 0b11000011, 0b00001001, 0b11011110, 0b10011101, 0b01010000, 0b10000001, 0b11000011, 0b01101010, 0b10010101, 0b01100001, 0b00000001, 0b11000010, 0b00000100, 0b01110100, 0b00110010, 0b11100100, 0b00110010, 0b01110110, 0b00011001, 0b11000100, 0b01101110, 0b11101010, 0b01101001, 0b10101011, 0b01011001, 0b10101110, 0b11100010, 0b11100000 };
            byte[] output = LZWDecoder.Decode(message, 16);
            string outp = "";
            for (int i = 0; i < output.Length; i++)
            {
                outp += (char)output[i];
            }
            Assert.AreEqual("A robot may not injure a human being or, through inaction, allow a human being to come to harm. A robot must obey the orders given to it by human beings, except where such orders would conflict with the First Law. A robot must protect its own existence.", outp);
        }

        [Test()]
        public void ShortTextDecodeTest()
        {
            // Generated using https://planetcalc.com/9069/
            byte[] message = new byte[] { 0b01000001, 0b00010000, 0b00010100, 0b11001001, 0b00000100, 0b00010010, 0b00001001, 0b01010000, 0b01000000, 0b01010100, 0b00100000, 0b10010100, 0b11100000, 0b11010000, 0b01011000, 0b00111100, 0b00010010, 0b00000011, 0b00000011, 0b10000110, 0b01000010, 0b00100001, 0b10110000, 0b01000010, 0b10100100, 0b00100000, 0b10000010 };
            byte[] output = LZWDecoder.Decode(message, 16);
            string outp = "";
            for (int i = 0; i < output.Length; i++)
            {
                outp += (char)output[i];
            }
            Assert.AreEqual("A SHAAT TAST AT TAA SHAAT TA TAAATTAA", outp);
        }

    }
}