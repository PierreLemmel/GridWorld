using System;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public sealed class GridCell<T>
    {
        public int Row { get; }
        public int Column { get; }
        public Grid<T> Grid { get; }
        public T Value { get; set; }

        internal GridCell(Grid<T> grid, int row, int column, T value)
        {
            Check.NotNull(grid, nameof(grid));
            Grid = grid;

            Check.IsInInterval(row, 0, Grid.Height);
            Row = row;

            Check.IsInInterval(column, 0, Grid.Width);
            Column = column;
            
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
                int minRow = Math.Max(0, Row - 1);
                int maxRow = Math.Min(Row + 1, Grid.Height - 1);
                int minCol = Math.Max(0, Column - 1);
                int maxCol = Math.Min(Column + 1, Grid.Width - 1);

                for (int row = minRow; row <= maxRow; row++)
                {
                    for (int col = minCol; col <= maxCol; col++)
                    {
                        if (row == Row || col == Column) continue;

                        yield return Grid[row, col];
                    }
                }
            }
        }
    }
}
