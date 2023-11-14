using Sudoku.Factories;
using Sudoku.HelperMethods;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests.Models.Puzzle.Sections
{
    public class SectionNonetRowTests
    {
        PuzzleFactory _factory = new PuzzleFactory();

        [Theory]
        [InlineData(0, 0,
            "100000000000100000000000000000000000000000000000000010000000000000000000000000001",
            "100000000000100000000000100000000000000000000000000010000000000000000000000000001")]
        public void Solve_UsingNonetRowLogic_SolvesNonetRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonetRow = _factory.CreateNonetRow(null, elements, coords);
            nonetRow.SetSectionList(new List<SectionBase> { nonetRow });

            //Act
            nonetRow.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0,
            "100000000000100000000000000000000000000000000000000010000000000000000000000000000",
            "100000000000100000000000000000000000000000000000000010000000000000000000000000000")]
        public void Solve_UsingInsufficientData_ReturnsInputUnchanged(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonetRow = _factory.CreateNonetRow(null, elements, coords);
            nonetRow.SetSectionList(new List<SectionBase> { nonetRow });

            //Act
            nonetRow.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0,
            "190000000000190000000000000000000000000000000000000010000000000000000009000000001",
            "190000000000190000000000190000000000000000000000000010000000000000000009000000001")]
        public void Solve_UsingNewProgress_SolvedNonetRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonetRow = _factory.CreateNonetRow(null, elements, coords);
            nonetRow.SetSectionList(new List<SectionBase> { nonetRow });

            //Act
            nonetRow.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }
    }
}
