using System;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public sealed class GridCell<T>
    {
        public int RowIndex { get; }
        public int ColumnIndex { get; }

        public GridRow<T> Row { get { return Grid.Rows[RowIndex]; } }
        public GridColumn<T> Column { get { return Grid.Columns[ColumnIndex]; } }

        public Grid<T> Grid { get; }
        public T Value { get; set; }

        internal GridCell(Grid<T> grid, int row, int column, T value)
        {
            Check.NotNull(grid, nameof(grid));
            Grid = grid;

            Check.IsInInterval(row, 0, Grid.Height);
            RowIndex = row;

            Check.IsInInterval(column, 0, Grid.Width);
            ColumnIndex = column;
            
            Value = value;
        }

        internal GridCell(Grid<T> grid, int row, int column) : this (grid, row, column, default(T)) { }

        public static implicit operator T(GridCell<T> cell)
        {
            return cell.Value;
        }

        public IEnumerable<GridCell<T>> Neighbours
        {
            get
            {
                int minRow = Math.Max(0, RowIndex - 1);
                int maxRow = Math.Min(RowIndex + 1, Grid.Height - 1);
                int minCol = Math.Max(0, ColumnIndex - 1);
                int maxCol = Math.Min(ColumnIndex + 1, Grid.Width - 1);

                for (int row = minRow; row <= maxRow; row++)
                {
                    for (int col = minCol; col <= maxCol; col++)
                    {
                        if (row == RowIndex || col == ColumnIndex) continue;

                        yield return Grid[row, col];
                    }
                }
            }
        }
    }
}
