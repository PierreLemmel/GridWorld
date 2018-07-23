using System;
using System.Collections;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public sealed class GridColumnCollection<T> : IEnumerable<GridColumn<T>>
    {
        public Grid<T> Grid { get; }

        internal GridColumnCollection(Grid<T> grid)
        {
            Check.NotNull(grid);
            Grid = grid;
        }

        public GridColumn<T> this[int column]
        {
            get
            {
                if (column < 0 || column >= Grid.Width)
                    throw new IndexOutOfRangeException();

                return new GridColumn<T>(Grid, column);
            }
        }

        public IEnumerator<GridColumn<T>> GetEnumerator()
        {
            int width = Grid.Width;
            for (int col = 0; col < width; col++)
                yield return this[col];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
