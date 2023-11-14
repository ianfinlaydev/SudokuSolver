using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Models.Puzzle.Sections
{
    internal class SectionNonetColumn : SectionBase
    {
        internal SectionNonetColumn(List<SectionBase> sections, int[,] elements, (int row, int column) sectionCoords) : base(sections, elements, sectionCoords)
        {
            _sectionDimensions = (9, 3);
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
                    validColumns = 3;

                    //Get Column Index
                    for (int columnCoord = _sectionCoords.Column; columnCoord < _sectionCoords.Column + _sectionDimensions.Columns; columnCoord++)
                    {
                        if (ColumnContains(_missingValues[i], columnCoord))
                        {
                            validColumns--;
                        }
                        else
                        {
                            columnIndex = columnCoord;
                        }
                    }

                    //Get Row Index
                    for (int nonetRowCoord = _sectionCoords.Row; nonetRowCoord < _sectionCoords.Row + _sectionDimensions.Rows; nonetRowCoord += 3)
                    {
                        if (NonetContains(_missingValues[i], (nonetRowCoord, _sectionCoords.Column)) == false)
                        {
                            validRows = 3;
                            for (int rowCoord = nonetRowCoord; rowCoord < nonetRowCoord + 3; rowCoord++)
                            {
                                if (RowContains(_missingValues[i], rowCoord) || _elements[rowCoord, columnIndex] != 0)
                                {
                                    validRows--;
                                }
                                else
                                {
                                    rowIndex = rowCoord;
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
                for (int j = _sectionCoords.Column; j < _sectionCoords.Column + _sectionDimensions.Columns; j++)
                {
                    if (ColumnContains(i, j) == false)
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

            int validColumns = 3;
            for (int columnCoord = _sectionCoords.Row; columnCoord < _sectionCoords.Row + _sectionDimensions.Columns; columnCoord++)
            {
                if (ColumnContains(solvedValue, columnCoord))
                {
                    validColumns--;
                }
            }
            if (validColumns == 0)
            {
                _missingValues.Remove(solvedValue);
            }
        }
    }
}
