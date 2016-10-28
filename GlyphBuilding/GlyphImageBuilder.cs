namespace GlyphsCreator.GlyphBuilding
    {
    using System.Collections;
    using System.Drawing;

    public class GlyphImageBuilder
        {
        private GlyphMatrixCreator glyphMatrixCreator = new GlyphMatrixCreator();

        private Bitmap getBitmap(BitArray binaryData, int bitmapWidth)
            {
            var glyphResolution = GlyphMatrixCreator.STANDARD_GLYPH_RESOLUTION;
            var cellsPerRow = glyphResolution
                + 2;// left and right border cells

            int cellWidth = (int)((double)bitmapWidth / cellsPerRow);

            var result = new Bitmap(bitmapWidth, bitmapWidth);

            // fill all bitmap with white color
            using (Graphics graph = Graphics.FromImage(result))
                {
                Rectangle ImageSize = new Rectangle(0, 0, bitmapWidth, bitmapWidth);
                graph.FillRectangle(Brushes.White, ImageSize);
                }

            // draw black border
            for (var borderIndex = 0; borderIndex < cellsPerRow; borderIndex += 1)
                {
                setCell(result, cellWidth, borderIndex, 0, true);
                setCell(result, cellWidth, borderIndex, cellsPerRow - 1, true);

                setCell(result, cellWidth, 0, borderIndex, true);
                setCell(result, cellWidth, cellsPerRow - 1, borderIndex, true);
                }

            // draw all cells, including data bits, CRC, etc.
            for (var cellIndex = 0; cellIndex < binaryData.Length; cellIndex += 1)
                {
                int x = cellIndex % glyphResolution;
                int y = cellIndex / glyphResolution;
                setCell(result, cellWidth, x + 1, y + 1, binaryData[cellIndex]);                
                }

            return result;
            }

        // this method is for demonstration purposes only because it too slow, 
        // in real projects you should lock bitmap and use unsafe mode to reach pixels data via BitmapData class
        private void setCell(Bitmap bitmap, int cellWidth, int x, int y, bool isBlack)
            {
            Color color = isBlack ? Color.Black : Color.White;
            for (int xOffSet = 0; xOffSet < cellWidth; xOffSet++)
                {
                for (int yOffSet = 0; yOffSet < cellWidth; yOffSet++)
                    {
                    bitmap.SetPixel(x * cellWidth + yOffSet, y * cellWidth + xOffSet, color);
                    }
                }
            }

        public Image BuildGlyphImage(long glyphData, int glyphCodeType, int squareWidth)
            {
            BitArray binaryData = glyphMatrixCreator.BuildBitsArray(glyphData, glyphCodeType);

            Bitmap bitmap = getBitmap(binaryData, squareWidth);
            return bitmap;
            }
        }
    }
