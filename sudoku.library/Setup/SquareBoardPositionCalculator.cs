using System;

namespace Sudoku.Library.Setup
{
    public class SquareBoardPositionCalculator : ISquareBoardPositionCalculator
    {
        public bool IsSquare(int cellEntryCount)
        {
            return Math.Sqrt(cellEntryCount) % 1 == 0;
        }

        public int GetRow(int cellIndex, int cellsPerRow)
        {
            return cellIndex / cellsPerRow;
        }

        public int GetColumn(int cellIndex, int cellsPerColumn)
        {
            return cellIndex % cellsPerColumn;
        }

        public int GetSquare(int cellIndex, int cellsPerSquare)
        {
            var squareRoot = IntegerSquareRoot(cellsPerSquare);
            var rowContribution = GetRow(cellIndex, cellsPerSquare) / squareRoot;
            var columnContribution = squareRoot * (GetColumn(cellIndex, cellsPerSquare) / squareRoot);
            return rowContribution + columnContribution;
        }

        private int IntegerSquareRoot(int value)
        {
            return Convert.ToInt32(Math.Sqrt(value));
        }
    }
}
