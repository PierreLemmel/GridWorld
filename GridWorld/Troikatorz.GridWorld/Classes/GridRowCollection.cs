using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Troikatorz.GridWorld
{
    public sealed class GridRowCollection<T> : IEnumerable<GridRow<T>>
    {
        private readonly IReadOnlyList<GridRow<T>> rows;

        public Grid<T> Grid { get; }

        internal GridRowCollection(Grid<T> grid)
        {
            Check.NotNull(grid);
            Grid = grid;

            rows = Enumerable.Range(0, Grid.Height)
                .Select(colIndex => new GridRow<T>(Grid, colIndex))
                .ToList();
        }

        public GridRow<T> this[int row]
        {
            get
            {
                if (row < 0 || row >= Grid.Height)
                    throw new IndexOutOfRangeException();

                return rows[row];
            }
        }

        public IEnumerator<GridRow<T>> GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}