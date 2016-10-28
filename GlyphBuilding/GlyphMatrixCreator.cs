namespace GlyphsCreator.GlyphBuilding
    {
    using System;
    using System.Collections;
    using System.Text;

    public class GlyphMatrixCreator
        {
        public const int STANDARD_GLYPH_RESOLUTION = 7;

        private static BitArray toStandardBitsArray(string binValue)
            {
            var bitArray = new BitArray(STANDARD_GLYPH_RESOLUTION * STANDARD_GLYPH_RESOLUTION);

            // four bits to detect glyph rotation angle, 
            // four option possible: 0 degree, 90 degree, 180 degree and 270 degree
            const int DETECTION_OF_ROTATION_ANGLE_BITS_COUNT = 4;
            const int CRC8_BITS_COUNT = 8;
            var maxDataLength = bitArray.Length - DETECTION_OF_ROTATION_ANGLE_BITS_COUNT - CRC8_BITS_COUNT;

            var sourceLength = Math.Min(binValue.Length, maxDataLength);
            var lastIndex = STANDARD_GLYPH_RESOLUTION - 1;
            var crc8 = getCRC8(binValue);
            var crcIndex = 0;
            var bitIndex = 0;
            var sourceIndex = 0;
            for (int rowIndex = 0; rowIndex < STANDARD_GLYPH_RESOLUTION; rowIndex += 1)
                {
                for (int columnIndex = 0; columnIndex < STANDARD_GLYPH_RESOLUTION; columnIndex += 1)
                    {
                    bool bitValue = false;
                    if (rowIndex == 0 && columnIndex == 0)
                        {
                        // top left corner (always black)
                        bitValue = true;
                        }
                    else if ((columnIndex == lastIndex && (rowIndex == 0 || rowIndex == lastIndex))
                             || columnIndex == 0 && rowIndex == lastIndex)
                        {
                        // not top left corner (always white)
                        bitValue = false;
                        }
                    else if (sourceIndex < sourceLength)
                        {
                        // data bit
                        bitValue = binValue[sourceIndex] == '1';
                        sourceIndex += 1;
                        }
                    else
                        {
                        // crc bit
                        bitValue = ((crc8 << crcIndex) & 0x80) > 0;
                        crcIndex += 1;
                        }

                    bitArray[bitIndex] = bitValue;
                    bitIndex += 1;
                    }
                }

            return bitArray;
            }

        private static int getCRC8(string bitArray)
            {
            const int bitsToLoad = 8;
            int crc = Convert.ToInt32(bitArray[0]);

            for (var bitIndex = 1; bitIndex <= bitsToLoad; bitIndex++)
                {
                crc <<= 1;
                if (bitArray[bitIndex] == '1')
                    {
                    crc += 1;
                    }
                }

            int length = bitArray.Length;
            const int polinom = 0x31; //    x^8 + x^5 + x^4 + 1
            for (var bitIndex = bitsToLoad + 1; bitIndex < length; bitIndex++)
                {
                var xorFlag = (crc & 0x80) == 0x80;
                crc <<= 1;

                if (bitArray[bitIndex] == '1')
                    {
                    crc += 1;
                    }
                if (xorFlag)
                    {
                    crc ^= polinom;
                    }
                }

            return crc & 0xFF;
            }

        private static void AppendBitsString(StringBuilder destination, long codingValue, int bitsCount)
            {
            var tempBuffer = new StringBuilder();

            for (int bitIndex = 1; bitIndex <= bitsCount; bitIndex += 1)
                {
                bool bit = (codingValue % 2) == 1;
                tempBuffer.Append(bit ? "1" : "0");

                codingValue >>= 1;
                }

            destination.Append(reverse(tempBuffer.ToString()));
            }

        private static string reverse(string s)
            {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
            }

        public BitArray BuildBitsArray(long glyphDataValue, int glyphCodeType)
            {            
            var glyphData = new StringBuilder();

            AppendBitsString(glyphData, glyphCodeType, 2);
            AppendBitsString(glyphData, glyphDataValue, 35);

            // string is universal data container for standard and other possible glyph formats
            // also ideal for debugging
            return toStandardBitsArray(glyphData.ToString()); ;
            }
        }
    }
