using System.Collections;
using System.Collections.Generic;

namespace Sudoku.Library
{
    public class Board : ICollection<CellSet>
    {
        private ICollection<CellSet> _cellSets;

        public Board()
        {
            _cellSets = new List<CellSet>();
        }

        # region ICollection<CellSet>
        public int Count
            => _cellSets.Count;

        public bool IsReadOnly
            => _cellSets.IsReadOnly;

        public void Add(CellSet item)
            => _cellSets.Add(item);

        public void Clear()
            => _cellSets.Clear();

        public bool Contains(CellSet item)
            => _cellSets.Contains(item);

        public void CopyTo(CellSet[] array, int arrayIndex)
            => _cellSets.CopyTo(array, arrayIndex);

        public bool Remove(CellSet item)
            => _cellSets.Remove(item);

        public IEnumerator<CellSet> GetEnumerator()
            => _cellSets.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        # endregion
    }
}
