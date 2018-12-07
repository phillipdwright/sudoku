using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Library
{
    public class CellSet : ICollection<Cell>
    {
        private ICollection<Cell> _cells;

        public CellSet()
        {
            _cells = new List<Cell>();
        }

        # region ICollection<Cell>
        public int Count
            => _cells.Count;

        public bool IsReadOnly
            => _cells.IsReadOnly;

        public void Add(Cell item)
            => _cells.Add(item);

        public void Clear()
            => _cells.Clear();

        public bool Contains(Cell item)
            => _cells.Contains(item);

        public void CopyTo(Cell[] array, int arrayIndex)
            => _cells.CopyTo(array, arrayIndex);

        public IEnumerator<Cell> GetEnumerator()
            => _cells.GetEnumerator();

        public bool Remove(Cell item)
            => _cells.Remove(item);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        # endregion
    }
}
