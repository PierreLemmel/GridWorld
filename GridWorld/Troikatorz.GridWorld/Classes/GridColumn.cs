using System.Collections;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public sealed class GridColumn<T> : IEnumerable<GridCell<T>>
    {
        public int Column { get; }
        public Grid<T> Grid { get; }

        internal GridColumn(Grid<T> grid, int column)
        {
            Check.NotNull(grid, nameof(grid));
            Grid = grid;

            Check.IsInInterval(column, 0, grid.Width);
            Column = column;
        }

        public GridCell<T> this[int row]
        {
            get { return Grid[row, Column]; }
        }

        public IEnumerator<GridCell<T>> GetEnumerator()
        {
            int height = Grid.Height;
            for (int row = 0; row < height; row++)
                yield return this[row];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
