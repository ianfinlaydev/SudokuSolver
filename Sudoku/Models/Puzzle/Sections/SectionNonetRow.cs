using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Models.Puzzle.Sections
{
    internal class SectionNonetRow : SectionBase
    {
        internal SectionNonetRow(List<SectionBase> sections, int[,] elements, (int row, int column) sectionCoords) : base(sections, elements, sectionCoords)
        {
            _sectionDimensions = (3, 9);
            _emptyElementCoords = GetEmptyElementCoords();
            _missingValues = GetMissingValues();
        }

        internal override void Solve()
        {
            bool hasProgressed;
            int rowIndex = -1;
            int validRows = -1;
            int columnIndex = -1;
            int validColumns = -1;
            do
            {
                hasProgressed = false;

                for (int i = _missingValues.Count - 1; i >= 0; i--)
                {
                    validRows = 3;

                    //Get Row Index
                    for (int rowCoord = _sectionCoords.Row; rowCoord < _sectionCoords.Row + _sectionDimensions.Rows; rowCoord++)
                    {
                        if (RowContains(_missingValues[i], rowCoord))
                        {
                            validRows--;
                        }
                        else
                        {
                            rowIndex = rowCoord;
                        }
                    }

                    //Get Column Index
                    for (int nonetColumnCoord = _sectionCoords.Column; nonetColumnCoord < _sectionCoords.Column + _sectionDimensions.Columns; nonetColumnCoord += 3)
                    {
                        if (NonetContains(_missingValues[i], (_sectionCoords.Row, nonetColumnCoord)) == false)
                        {
                            validColumns = 3;
                            for (int columnCoord = nonetColumnCoord; columnCoord < nonetColumnCoord + 3; columnCoord++)
                            {
                                if (ColumnContains(_missingValues[i], columnCoord) || _elements[rowIndex, columnCoord] != 0)
                                {
                                    validColumns--;
                                }
                                else
                                {
                                    columnIndex = columnCoord;
                                }
                            }
                        }
                    }

                    if (validRows == 1 && validColumns == 1 && _emptyElementCoords.Contains((rowIndex, columnIndex)))
                    {
                        _elements[rowIndex, columnIndex] = _missingValues[i];
                        UpdateSectionsAfterSolvedElement((rowIndex, columnIndex), _missingValues[i]);
                        hasProgressed = true;
                    }
                }
            } while (hasProgressed);
        }

        protected override List<int> GetMissingValues()
        {
            List<int> missingValues = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                for (int rowCoord = _sectionCoords.Row; rowCoord < _sectionCoords.Row + _sectionDimensions.Rows; rowCoord++)
                {
                    if (RowContains(i, rowCoord) == false)
                    {
                        missingValues.Add(i);
                        break;
                    }
                }
            }
            return missingValues;
        }

        protected override void Update((int, int) solvedCoords, int solvedValue)
        {
            _emptyElementCoords.Remove(solvedCoords);

            int validRows = 3;
            for (int rowCoord = _sectionCoords.Row; rowCoord < _sectionCoords.Row + _sectionDimensions.Rows; rowCoord++)
            {
                if (RowContains(solvedValue, rowCoord))
                {
                    validRows--;
                }
            }
            if (validRows == 0)
            {
                _missingValues.Remove(solvedValue);
            }
        }
    }
}
