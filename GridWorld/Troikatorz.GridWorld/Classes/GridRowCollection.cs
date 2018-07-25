using System;
using System.Collections;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public sealed class GridRowCollection<T> : IEnumerable<GridRow<T>>
    {
        public Grid<T> Grid { get; }

        internal GridRowCollection(Grid<T> grid)
        {
            Check.NotNull(grid);
            Grid = grid;
        }

        public GridRow<T> this[int row]
        {
            get
            {
                if (row < 0 || row >= Grid.Height)
                    throw new IndexOutOfRangeException();

                return new GridRow<T>(Grid, row);
            }
        }

        public IEnumerator<GridRow<T>> GetEnumerator()
        {
            int height = Grid.Height;
            for (int col = 0; col < height; col++)
                yield return this[col];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
