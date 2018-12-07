using System.Linq;

namespace Sudoku.Library.Validation
{
    public class CellSetValidator
    {
        public bool IsValid(CellSet cellSet)
        {
            return cellSet.Where(cell => cell.Value != null)
                .All(cell => !HasMatches(cell, cellSet));
        }

        private bool HasMatches(Cell cell, CellSet cellSet)
        {
            return cellSet.Except(new[] { cell })
                .Any(other => cell.Value == other.Value);
        }
    }
}
