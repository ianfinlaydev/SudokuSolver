using Sudoku.Factories;
using Sudoku.HelperMethods;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests.Models.Puzzle
{
    public class PuzzleTests
    {
        PuzzleFactory _factory = new PuzzleFactory();

        [Theory]
        [InlineData("900841300001900420000200010870100540150360002200000760720005190630000207015702008",
            "962841375581973426347256819876129543154367982293584761728635194639418257415792638")]
        public void Solve_UsingEasyPuzzle_SolvesPuzzle(string input, string expected)
        {
            //Arrange
            var elements = input.ToElements();
            var puzzle = _factory.CreatePuzzle(elements);

            //Act
            puzzle.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }
    }
}
