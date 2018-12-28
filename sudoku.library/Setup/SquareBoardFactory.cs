using System;
using System.Collections.Generic;

namespace Sudoku.Library.Setup
{
    public class SquareBoardFactory
    {
        private ISquareBoardPositionCalculator _positionCalculator;

        public SquareBoardFactory(ISquareBoardPositionCalculator positionCalculator)
        {
            _positionCalculator = positionCalculator;
        }

        public Board Create(int cellEntries)
        {
            if (!_positionCalculator.IsSquare(cellEntries))
                throw new ArgumentException($"Invalid number of cell entries: {cellEntries}. Number of cell entries must be square.");

            var board = new Board();

            var rows = CreateCellSetsIn(board, cellEntries);
            var columns = CreateCellSetsIn(board, cellEntries);
            var squares = CreateCellSetsIn(board, cellEntries);
            
            for (var i = 0; i < cellEntries * cellEntries; i++)
                AddNewCell(i, cellEntries, rows, columns, squares);

            return board;
        }

        private void AddNewCell(int cellIndex, int cellEntries, IList<CellSet> rows, IList<CellSet> columns, IList<CellSet> squares)
        {
            var cell = new Cell();

            var rowIndex = _positionCalculator.GetRow(cellIndex, cellEntries);
            rows[rowIndex].Add(cell);

            var columnIndex = _positionCalculator.GetColumn(cellIndex, cellEntries);
            columns[columnIndex].Add(cell);

            var squareIndex = _positionCalculator.GetSquare(cellIndex, cellEntries);
            squares[squareIndex].Add(cell);
        }

        private IList<CellSet> CreateCellSetsIn(Board board, int cellEntries)
        {
            var cellSets = new CellSet[cellEntries];
            for (var i = 0; i < cellEntries; i++)
            {
                var cellSet = new CellSet();
                board.Add(cellSet);
                cellSets[i] = cellSet;
            }
            return cellSets;
        }
    }
}
