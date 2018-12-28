namespace Sudoku.Library.Setup
{
    public interface IBoardPositionCalculator
    {
        int GetRow(int cellIndex, int cellsPerRow);
        int GetColumn(int cellIndex, int cellsPerColumn);
        int GetSquare(int cellIndex, int cellsPerSquare);
    }
}
