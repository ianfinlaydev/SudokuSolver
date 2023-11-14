using Sudoku.Factories;
using Sudoku.HelperMethods;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests.Models.Puzzle.Sections
{
    public class SectionNonetColumnTests
    {
        PuzzleFactory _factory = new PuzzleFactory();

        [Theory]
        [InlineData(0, 0,
            "100000000000000000000000000010000000000000000000000000000000000000100000000000100",
            "100000000000000000000000000010000000000000000000000000001000000000100000000000100")]
        public void Solve_UsingNonetColumnLogic_SolvesColumnRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonetColumn = _factory.CreateNonetColumn(null, elements, coords);
            nonetColumn.SetSectionList(new List<SectionBase> { nonetColumn });

            //Act
            nonetColumn.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0,
            "100000000000000000000000000010000000000000000000000000000000000000100000000000000",
            "100000000000000000000000000010000000000000000000000000000000000000100000000000000")]
        public void Solve_UsingInsufficientData_ReturnsInputUnchanged(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonetColumn = _factory.CreateNonetColumn(null, elements, coords);
            nonetColumn.SetSectionList(new List<SectionBase> { nonetColumn });

            //Act
            nonetColumn.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0,
            "100000000900000000000000000010000000090000000000000000000000000000100000000000190",
            "100000000900000000000000000010000000090000000000000000001000000009100000000000190")]
        public void Solve_UsingNewProgress_SolvedNonetColumn(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonetColumn = _factory.CreateNonetColumn(null, elements, coords);
            nonetColumn.SetSectionList(new List<SectionBase> { nonetColumn });

            //Act
            nonetColumn.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }
    }
}
