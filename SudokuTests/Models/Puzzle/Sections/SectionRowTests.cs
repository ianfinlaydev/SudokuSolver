using Sudoku.Factories;
using Sudoku.HelperMethods;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests
{
    public class SectionRowTests
    {
        PuzzleFactory _factory = new PuzzleFactory();

        [Theory]
        [InlineData(0, 0,
            "023456789000000000000000000000000000000000000000000000000000000000000000000000000",
            "123456789000000000000000000000000000000000000000000000000000000000000000000000000")] //1 Missing Element
        public void Solve_UsingRowLogic_SolvesRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var row = _factory.CreateRow(null, elements, coords);
            row.SetSectionList(new List<SectionBase> { row });

            //Act
            row.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 0,
            "000000100023456089000000000000000000000000000000000000000000000000000000000000000",
            "000000100123456789000000000000000000000000000000000000000000000000000000000000000")] //2 Missing Elements
        [InlineData(2, 0,
            "000000000000000000000456789001000000002000000000000000010000000000000000000000000",
            "000000000000000000123456789001000000002000000000000000010000000000000000000000000")] //3 Missing Elements
        [InlineData(3, 0,
            "000000006000000007000000008123450000000000060000000000000000070000000000000007000",
            "000000006000000007000000008123456789000000060000000000000000070000000000000007000")] //4 Missing Elements
        public void Solve_UsingColumnLogic_SolvesRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var row = _factory.CreateRow(null, elements, coords);
            row.SetSectionList(new List<SectionBase> { row });

            //Act
            row.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, 0,
            "000000000000000000000000000000000000000000000000000000023056089456789123789123456",
            "000000000000000000000000000000000000000000000000000000123456789456789123789123456")]
        public void Solve_UsingNonetLogic_SolvesRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var row = _factory.CreateRow(null, elements, coords);
            row.SetSectionList(new List<SectionBase> { row });

            //Act
            row.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0,
            "003056789040000000000000000200000000000000000000000000000000000000000000000000000",
            "123456789040000000000000000200000000000000000000000000000000000000000000000000000")]
        public void Solve_UsingColumnAndNonetLogic_SolvesRow(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var row = _factory.CreateRow(null, elements, coords);
            row.SetSectionList(new List<SectionBase> { row });

            //Act
            row.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }
    }
}
