using System.Linq;

namespace Sudoku.Library.Validation
{
    public class BoardValidator
    {
        private ICellSetValidator _cellSetValidator;

        public BoardValidator(ICellSetValidator cellSetValidator)
        {
            _cellSetValidator = cellSetValidator;
        }

        public bool IsValid(Board board)
        {
            return !board.Any(IsInvalidCellSet);
        }

        private bool IsInvalidCellSet(CellSet cellSet)
            => !_cellSetValidator.IsValid(cellSet);
    }
}
