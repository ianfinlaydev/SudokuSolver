using Sudoku.Factories;
using Sudoku.Models.Puzzle;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sudoku
{
    class Program
    {
        static PuzzleFactory _factory = new PuzzleFactory();

        static void Main(string[] args)
        {
            try
            {
                int[,] elements = null; //Get puzzle elements
                var puzzle = _factory.CreatePuzzle(elements);
                puzzle.Solve();
                Console.WriteLine(puzzle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
