using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Troikatorz.GridWorld
{
    public sealed class GridColumnCollection<T> : IEnumerable<GridColumn<T>>
    {
        private readonly IReadOnlyList<GridColumn<T>> columns;

        public Grid<T> Grid { get; }

        internal GridColumnCollection(Grid<T> grid)
        {
            Check.NotNull(grid);
            Grid = grid;

            columns = Enumerable.Range(0, Grid.Width)
                .Select(colIndex => new GridColumn<T>(Grid, colIndex))
                .ToList();
        }

        public GridColumn<T> this[int column]
        {
            get
            {
                if (column < 0 || column >= Grid.Width)
                    throw new IndexOutOfRangeException();

                return columns[column];
            }
        }

        public IEnumerator<GridColumn<T>> GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}