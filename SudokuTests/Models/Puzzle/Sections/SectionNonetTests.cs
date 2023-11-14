using Sudoku.Factories;
using Sudoku.HelperMethods;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SudokuTests.Models.Puzzle.Sections
{
    public class SectionNonetTests
    {
        PuzzleFactory _factory = new PuzzleFactory();

        [Theory]
        [InlineData(6, 6,
            "000000000000000000000000000000000000000000000000000000000000023000000456000000789",
            "000000000000000000000000000000000000000000000000000000000000123000000456000000789")] // 1 missing element
        public void Solve_UsingNonetLogic_SolvesNonet(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonet = _factory.CreateNonet(null, elements, coords);
            nonet.SetSectionList(new List<SectionBase> { nonet });

            //Act
            nonet.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 3,
            "000123000090056000000780000000000000000000000000000000000000000000000000000000000",
            "000123000090456000000789000000000000000000000000000000000000000000000000000000000")] // 2 missing elements
        [InlineData(3, 3,
            "000000000000000000000000000000907000080054000060301008000000000000000000000000000",
            "000000000000000000000000000000987000080654000060321008000000000000000000000000000")] //3 missing elements
        public void Solve_UsingRowLogic_SolvesNonet(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonet = _factory.CreateNonet(null, elements, coords);
            nonet.SetSectionList(new List<SectionBase> { nonet });

            //Act
            nonet.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 0,
            "007000000000000000000000000120000000456000000089000000000000000000000000000000000",
            "007000000000000000000000000123000000456000000789000000000000000000000000000000000")] // 2 missing elements
        [InlineData(6, 0,
            "500000000900000000000000000090000000000000000000000000023000000406000000780000000",
            "500000000900000000000000000090000000000000000000000000123000000456000000789000000")] // 3 missing elements
        public void Solve_UsingColumnLogic_SolvesNonet(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonet = _factory.CreateNonet(null, elements, coords);
            nonet.SetSectionList(new List<SectionBase> { nonet });

            //Act
            nonet.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, 3,
            "000900000000000000000000000000000000000000000000000000500023000000406009000780000",
            "000900000000000000000000000000000000000000000000000000500123000000456009000789000")] // 3 missing elements
        [InlineData(0, 0,
            "023000000006700100089140000010000000040000000000000000000000000000000000000000000",
            "123000000456700100789140000010000000040000000000000000000000000000000000000000000")] // 4 missing elements
        public void Solve_UsingColumnAndRowLogic_SolvesNonet(int rowCoord, int columnCoord, string input, string expected)
        {
            //Arrange
            var coords = (rowCoord, columnCoord);
            var elements = input.ToElements();
            var nonet = _factory.CreateNonet(null, elements, coords);
            nonet.SetSectionList(new List<SectionBase> { nonet });

            //Act
            nonet.Solve();

            //Assert
            var actual = elements.ToStringExtended();
            Assert.Equal(expected, actual);
        }
    }
}
