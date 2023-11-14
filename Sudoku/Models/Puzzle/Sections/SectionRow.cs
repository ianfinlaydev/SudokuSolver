using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Models.Puzzle.Sections
{
    internal class SectionRow : SectionBase
    {
        internal SectionRow(List<SectionBase> sections, int[,] elements, (int row, int column) sectionCoords) : base(sections, elements, sectionCoords)
        {
            _sectionDimensions = (1, 9);
            _emptyElementCoords = GetEmptyElementCoords();
            _missingValues = GetMissingValues();
        }

        internal override void Solve()
        {
            bool hasProgressed;
            do
            {
                hasProgressed = false;
                if (_emptyElementCoords.Count <= 4)
                {
                    for (int i = _emptyElementCoords.Count - 1; i >= 0; i--)
                    {
                        List<int> candidateValues = _missingValues.ToList();

                        candidateValues.RemoveAll(
                            value => NonetContains(value, _emptyElementCoords[i]) || ColumnContains(value, _emptyElementCoords[i].Column));

                        if (candidateValues.Count == 1)
                        {
                            int value = candidateValues.First();
                            _elements[_emptyElementCoords[i].Row, _emptyElementCoords[i].Column] = value;
                            UpdateSectionsAfterSolvedElement(_emptyElementCoords[i], value);
                            hasProgressed = true;
                        }
                    }
                }
            } while (hasProgressed);
        }
    }
}
