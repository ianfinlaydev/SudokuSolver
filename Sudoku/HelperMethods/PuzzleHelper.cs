using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.HelperMethods
{
    public static class PuzzleHelper
    {
        public static int[,] ToElements(this string puzzleString)
        {
            int[,] elements = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    elements[i, j] = (int)char.GetNumericValue(puzzleString[(9 * i) + j]);
                }
            }
            return elements;
        }

        public static string ToStringExtended(this int[,] array)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    builder.Append(array[i, j]);
                }
            }
            return builder.ToString();
        }

        public static bool EqualsExtended(this int[,] array1, int[,] array2)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (array1[i, j] != array2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
