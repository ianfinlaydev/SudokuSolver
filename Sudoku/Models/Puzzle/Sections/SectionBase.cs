using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("SudokuTests")]

namespace Sudoku.Models.Puzzle.Sections
{
    internal abstract class SectionBase
    {
        protected int[,] _elements;
        List<SectionBase> _sections;
        protected (int Rows, int Columns) _sectionDimensions;
        protected (int Row, int Column) _sectionCoords;
        protected List<(int Row, int Column)> _emptyElementCoords;
        protected List<int> _missingValues;

        internal SectionBase(List<SectionBase> sections, int[,] elements, (int row, int column) sectionsCoords)
        {
            _sections = sections;
            _elements = elements;
            _sectionCoords = sectionsCoords;
        }

        internal abstract void Solve();

        protected virtual void Update((int, int) solvedCoords, int solvedValue)
        {
            _emptyElementCoords.Remove(solvedCoords);
            _missingValues.Remove(solvedValue);
        }

        protected virtual void UpdateSectionsAfterSolvedElement((int, int) solvedCoords, int solvedValue)
        {
            foreach (var section in _sections.Where(s => SectionContainsCoords(solvedCoords)))
            {
                section.Update(solvedCoords, solvedValue);
            }
        }

        protected bool IsMinorSection()
        {
            Type type = GetType();
            return type == typeof(SectionRow) || type == typeof(SectionColumn) || type == typeof(SectionNonet);
        }

        protected bool IsMajorSection()
        {
            Type type = GetType();
            return type == typeof(SectionNonetRow) || type == typeof(SectionNonetColumn);
        }

        protected bool SectionContainsCoords((int row, int column) coords) =>
            coords.row >= _sectionCoords.Row &&
            coords.row < _sectionCoords.Row + _sectionDimensions.Rows &&
            coords.column >= _sectionCoords.Column &&
            coords.column <= _sectionCoords.Column + _sectionDimensions.Columns;

        protected List<(int, int)> GetEmptyElementCoords()
        {
            List<(int, int)> emptyElements = new List<(int, int)>();
            for (int i = _sectionCoords.Row; i < _sectionCoords.Row + _sectionDimensions.Rows; i++)
            {
                for (int j = _sectionCoords.Column; j < _sectionCoords.Column + _sectionDimensions.Columns; j++)
                {
                    if (_elements[i, j] == 0)
                    {
                        emptyElements.Add((i, j));
                    }
                }
            }
            return emptyElements;
        }

        protected virtual List<int> GetMissingValues()
        {
            List<int> missingValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = _sectionCoords.Row; i < _sectionCoords.Row + _sectionDimensions.Rows; i++)
            {
                for (int j = _sectionCoords.Column; j < _sectionCoords.Column + _sectionDimensions.Columns; j++)
                {
                    missingValues.Remove(_elements[i, j]);
                }
            }
            return missingValues;
        }

        protected bool NonetContains(int target, (int row, int column) elementCoords)
        {
            int nonetCoord1 = (elementCoords.row < 3) ? 0 : (elementCoords.row < 6) ? 3 : 6;
            int nonetCoord2 = (elementCoords.column < 3) ? 0 : (elementCoords.column < 6) ? 3 : 6;

            for (int i = nonetCoord1; i < nonetCoord1 + 3; i++)
            {
                for (int j = nonetCoord2; j < nonetCoord2 + 3; j++)
                {
                    if (_elements[i, j] == target)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool ColumnContains(int target, int columnCoord)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_elements[i, columnCoord] == target)
                {
                    return true;
                }
            }
            return false;
        }

        protected bool RowContains(int target, int rowCoord)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_elements[rowCoord, i] == target)
                {
                    return true;
                }
            }
            return false;
        }

        internal void SetSectionList(List<SectionBase> sections)
        {
            _sections = sections;
        }

        internal bool IsValid()
        {
            HashSet<int> values = new HashSet<int>();

            for (int i = _sectionCoords.Row; i < _sectionCoords.Row + _sectionDimensions.Rows; i++)
            {
                for (int j = _sectionCoords.Column; j < _sectionCoords.Column + _sectionDimensions.Columns; j++)
                {
                    if (values.Add(_elements[i, j]) == false)
                    {
                        return false;
                    }                    
                }
            }
            return true;
        }

        internal int EmptyElementCount() => _emptyElementCoords == null ? 0 : _emptyElementCoords.Count;
    }
}
