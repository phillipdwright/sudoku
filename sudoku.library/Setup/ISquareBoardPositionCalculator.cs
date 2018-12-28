namespace Sudoku.Library.Setup
{
    public interface ISquareBoardPositionCalculator : IBoardPositionCalculator
    {
        bool IsSquare(int cellEntryCount);
    }
}
