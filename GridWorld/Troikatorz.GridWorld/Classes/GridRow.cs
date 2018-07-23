using System.Collections;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public sealed class GridRow<T> : IEnumerable<GridCell<T>>
    {
        public int Row { get; }
        public Grid<T> Grid { get; }

        internal GridRow(Grid<T> grid, int row)
        {
            Check.NotNull(grid, nameof(grid));
            Grid = grid;

            Check.IsInInterval(row, 0, grid.Height);
            Row = row;
        }

        public GridCell<T> this[int column]
        {
            get { return Grid[Row, column]; }
        }

        public IEnumerator<GridCell<T>> GetEnumerator()
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
