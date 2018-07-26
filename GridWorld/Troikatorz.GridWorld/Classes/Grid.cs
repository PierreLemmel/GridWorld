using System.Collections;
using System.Collections.Generic;

namespace Troikatorz.GridWorld
{
    public class Grid<T> : IEnumerable<GridCell<T>>
    {
        private GridCell<T>[,] cells;

        public int Width { get { return cells.GetLength(1); } }
        public int Height { get { return cells.GetLength(0); } }

        public GridRowCollection<T> Rows { get; }
        public GridColumnCollection<T> Columns { get; }

        public Grid(T[,] values)
        {
            Check.NotNull(values, nameof(values));

            int width = values.GetLength(1);
            int height = values.GetLength(0);

            Check.IsStrictlyPositive(width);
            Check.IsStrictlyPositive(height);

            CreateCells(width, height);
            InitializeCells(values);

            Rows = new GridRowCollection<T>(this);
            Columns = new GridColumnCollection<T>(this);
        }

        public Grid(int width, int height, T defaultValue)
        {
            Check.IsStrictlyPositive(width);
            Check.IsStrictlyPositive(height);

            CreateCells(width, height);
            InitializeCells(defaultValue);

            Rows = new GridRowCollection<T>(this);
            Columns = new GridColumnCollection<T>(this);
        }

        public Grid(int width, int height) : this(width, height, default(T)) { }
        
        public Grid(int size, T defaultValue) : this(size, size, defaultValue) { }

        public Grid(int size) : this(size, default(T)) { }

        public GridCell<T> this[int row, int col]
        {
            get { return cells[row, col]; }
        }

        private void CreateCells(int width, int height)
        {
            cells = new GridCell<T>[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    cells[row, col] = new GridCell<T>(this, row, col);
                }
            }
        }

        private void InitializeCells(T[,] values)
        {
            int width = this.Width;
            int height = this.Height;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    GridCell<T> cell = this[row, col];
                    cell.Value = values[row, col];
                }
            }
        }

        private void InitializeCells(T value)
        {
            foreach (GridCell<T> cell in this)
                cell.Value = value;
        }

        public IEnumerator<GridCell<T>> GetEnumerator()
        {
            int width = this.Width;
            int height = this.Height;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    yield return cells[row, col];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
