using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace VixenPlus
{
    public class HouseEffect
    {
        private int rows, columns;
        private byte[,] data;
        private string name;
        private string path;

        public static HouseEffect FromSelection(byte[,] values, Rectangle selectedRectangle, Func<int, int> rowMap, string path)
        {
            int top = selectedRectangle.Top;
            int bottom = selectedRectangle.Bottom;
            int right = selectedRectangle.Right;
            int left = selectedRectangle.Left;

            int rows = bottom - top;
            int columns = right - left;

            HouseEffect effect = new HouseEffect();
            effect.path = path;
            effect.name = Path.GetFileNameWithoutExtension(path);
            effect.rows = rows;
            effect.columns = columns;
            effect.data = new byte[rows, columns];


            for (int row = top; row < bottom; ++row) {
                int mappedRow = rowMap(row);

                for (int col = left; col < right; ++col) {
                    byte val = values[mappedRow, col];
                    effect.data[row - top, col - left] = val;
                }
            }

            return effect;
        }

        public int Width { get { return columns; } }

        public int Height { get { return rows; } }


        public static HouseEffect Load(string path)
        {
            HouseEffect effect = new HouseEffect();

            using (TextReader reader = new StreamReader(path)) {
                int rows = int.Parse(reader.ReadLine());
                int columns = int.Parse(reader.ReadLine());

                effect.path = path;
                effect.name = Path.GetFileNameWithoutExtension(path);
                effect.rows = rows;
                effect.columns = columns;
                effect.data = new byte[rows, columns];

                for (int row = 0; row < rows; ++row) {
                    for (int col = 0; col < columns; ++col) {
                        byte val = (byte)int.Parse(reader.ReadLine());
                        effect.data[row, col] = val;
                    }
                }
            }

            return effect;
        }

        public void Save()
        {
            using (TextWriter writer = new StreamWriter(path)) {

                writer.WriteLine("{0}", rows);
                writer.WriteLine("{0}", columns);

                for (int row = 0; row < rows; ++row) {
                    for (int col = 0; col < columns; ++col) {
                        int val = data[row, col];
                        writer.WriteLine("{0}", val);
                    }
                }
            }

        }

        public void PlaceAt(byte[,] valueArray, int top, int left, Func<int, int> rowMap)
        {
            int totalRows = valueArray.GetLength(0);
            int totalCols = valueArray.GetLength(1);

            for (int row = 0; row < rows; ++row) {
                int destRow = rowMap(row + top);
                if (destRow < 0)
                    continue;

                for (int col = 0; col < columns; ++col) {
                    int destcol = col + left;
                    if (destRow >= 0 && destRow < totalRows && destcol >= 0 && destcol < totalCols) {
                        valueArray[destRow, destcol] = data[row, col];
                    }
                }
            }
        }

        public void PlaceAtStretch(byte[,] valueArray, int top, int left, int width, Func<int, int> rowMap)
        {
            int totalRows = valueArray.GetLength(0);
            int totalCols = valueArray.GetLength(1);

            for (int row = 0; row < rows; ++row) {
                int destRow = rowMap(row + top);
                if (destRow < 0)
                    continue;

                for (int col = 0; col < width; ++col) {
                    int destcol = col + left;
                    if (destRow >= 0 && destRow < totalRows && destcol >= 0 && destcol < totalCols) {
                        int scaledCol = (int) (((double)col / (double)width) * columns);
                        valueArray[destRow, destcol] = data[row, scaledCol];
                    }
                }
            }
        }
    }

}
