using Sudoku.Models.Puzzle;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Factories
{
    public class PuzzleFactory
    {
        internal Puzzle CreatePuzzle(int[,] elements) => new Puzzle(this, elements);

        internal SectionBase CreateRow(List<SectionBase> sections, int[,] elements, (int, int) sectionCoords) => new SectionRow(sections, elements, sectionCoords);

        internal SectionBase CreateColumn(List<SectionBase> sections, int[,] elements, (int, int) sectionCoords) => new SectionColumn(sections, elements, sectionCoords);

        internal SectionBase CreateNonet(List<SectionBase> sections, int[,] elements, (int, int) sectionCoords) => new SectionNonet(sections, elements, sectionCoords);

        internal SectionBase CreateNonetRow(List<SectionBase> sections, int[,] elements, (int, int) sectionCoords) => new SectionNonetRow(sections, elements, sectionCoords);

        internal SectionBase CreateNonetColumn(List<SectionBase> sections, int[,] elements, (int, int) sectionCoords) => new SectionNonetColumn(sections, elements, sectionCoords);
    }
}
