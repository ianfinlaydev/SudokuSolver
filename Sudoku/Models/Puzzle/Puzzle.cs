using Sudoku.Factories;
using Sudoku.Models.Puzzle.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Models.Puzzle
{
    public class Puzzle
    {
        PuzzleFactory _factory;
        private int[,] _elements;
        private List<SectionBase> _sections;

        public Puzzle(PuzzleFactory factory, int[,] elements)
        {
            _factory = factory;
            _elements = elements;
            _sections = BuildPuzzleSections();
            if (IsValid() == false)
            {
                //TODO: Add more detailed error messaging
                throw new Exception("Puzzle is invalid format.");
            }
        }

        internal List<SectionBase> BuildPuzzleSections()
        {
            List<SectionBase> sections = new List<SectionBase>();

            //Build Rows
            for (int i = 0; i < 9; i++)
            {
                var row = _factory.CreateRow(sections, _elements, (i, 0));
                sections.Add(row);
            }

            //Build Columns
            for (int i = 0; i < 9; i++)
            {
                var column = _factory.CreateColumn(sections, _elements, (0, i));
                sections.Add(column);
            }

            //Build Nonets
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    var nonet = _factory.CreateNonet(sections, _elements, (0, i));
                    sections.Add(nonet);
                }
            }

            //Build NonetRows
            for (int i = 0; i < 9; i += 3)
            {
                var nonetRow = _factory.CreateNonetRow(sections, _elements, (0, i));
                sections.Add(nonetRow);
            }

            //Build NonetColumns
            for (int i = 0; i < 9; i += 3)
            {
                var nonetColumn = _factory.CreateNonetColumn(sections, _elements, (0, i));
                sections.Add(nonetColumn);
            }

            return sections;
        }

        public void Solve()
        {
            long iterationCounter = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine("Puzzle has begun solving...");
            while (_sections.Sum(ps => ps.EmptyElementCount()) > 0)
            {
                foreach (var section in _sections)
                {
                    section.Solve();
                }
                iterationCounter++;
                Console.WriteLine($"Iteration: '{iterationCounter}', Running Time: '{watch.ElapsedMilliseconds} ms'");
            }

            watch.Stop();

            Console.WriteLine("Puzzle has been solved...");
            Console.WriteLine($"Puzzle was solved in '{watch.ElapsedMilliseconds}' ms");
            Console.WriteLine($"Puzzle was solved in '{iterationCounter}' iterations");
        }

        internal bool IsValid()
        {
            foreach (var section in _sections)
            {
                if (section.IsValid() == false)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    builder.Append(_elements[i, j]);
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}
