using Sudoku.Factories;
using Sudoku.HelperMethods;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests
{
    public class SectionColumnTests
    {
        PuzzleFactory _factory = new PuzzleFactory();

        [Theory]
        [InlineData(0, 0,
            "000000000200000000300000000400000000500000000600000000700000000800000000900000000",
            "100000000200000000300000000400000000500000000600000000700000000800000000900000000")] //1 Missing Element
        public void Solve_UsingColumnLogic_SolvesColumn(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var column = _factory.CreateColumn(null, elements, coords);
            column.SetSectionList(new List<SectionBase> { column });

            //Act
            column.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 1,
            "000000000020000000030000000040000000050000000060000000001000000080000000090000000",
            "010000000020000000030000000040000000050000000060000000071000000080000000090000000")] //2 Missing Elements
        [InlineData(0, 2,
            "000000000000000001000102000004000000005000000006000000007000000008000000009000000",
            "001000000002000001003102000004000000005000000006000000007000000008000000009000000")] //3 Missing Elements
        [InlineData(0, 3,
            "000100000000200000000300000000400000000500000700000000000000000000000067067000008",
            "000100000000200000000300000000400000000500000700600000000700000000800067067900008")] //4 Missing Elements
        public void Solve_UsingRowLogic_SolvesColumn(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var column = _factory.CreateColumn(null, elements, coords);
            column.SetSectionList(new List<SectionBase> { column });

            //Act
            column.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 6,
            "000000023000000456000000789000000034000000567000000891000000045000000678000000912",
            "000000123000000456000000789000000234000000567000000891000000345000000678000000912")]
        public void Solve_UsingNonetLogic_SolvesColumn(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var column = _factory.CreateColumn(null, elements, coords);
            column.SetSectionList(new List<SectionBase> { column });

            //Act
            column.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0,
            "000200000040000000300000000000000000500000000600000000700000000800000000900000000",
            "100200000240000000300000000400000000500000000600000000700000000800000000900000000")]
        public void Solve_UsingRowAndNonetLogic_SolvesColumn(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var column = _factory.CreateColumn(null, elements, coords);
            column.SetSectionList(new List<SectionBase> { column });

            //Act
            column.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }
    }
}
