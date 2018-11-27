namespace Sudoku.Library
{
    public class Cell
    {
        public bool IsEmpty => !Value.HasValue;
        public CellValue? Value { get; set; }
    }
}
