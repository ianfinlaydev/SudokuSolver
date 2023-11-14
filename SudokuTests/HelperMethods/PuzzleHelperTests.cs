using Sudoku.HelperMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests.HelperMethods
{
    public class PuzzleHelperTests
    {
        [Theory]
        [ClassData(typeof(PuzzleHelperTestData))]
        public void ToElements_UsingString_TransformIntoElementArray(string input, int[,] expected)
        {
            //Act
            int[,] actual = input.ToElements();

            //Assert
            Assert.True(expected.EqualsExtended(actual));
        }

        [Theory]
        [ClassData(typeof(PuzzleHelperTestData))]
        public void ToStringExtended_UsingElementArray_TransformIntoString(string expected, int[,] input)
        {
            //Act
            string actual = input.ToStringExtended();

            //Assert
            Assert.Equal(expected, actual);
        }

        public class PuzzleHelperTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] 
                {
                    "123456789123456789123456789123456789123456789123456789123456789123456789123456789",
                    new int[,] {
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                    }
                };
                yield return new object[]
                {
                    "987654321987654321987654321987654321987654321987654321987654321987654321987654321",
                    new int[,] {
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                        { 9, 8, 7, 6, 5, 4, 3, 2, 1 }
                    }
                };
                yield return new object[]
                {
                    "123456789456789123789123456234567891567891234891234567345678912678912345912345678",
                    new int[,] {
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                        { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                        { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                        { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
                        { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
                        { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
                        { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
                        { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
