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
    }
}
