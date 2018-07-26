using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Troikatorz.GridWorld.Tests
{
    [TestFixture(TestOf = typeof(GridCell<>))]
    public class GridCellTests
    {
        private const int GRID_WIDTH = 25;
        private const int GRID_HEIGHT = 42;

        [Test]
        public void GridCell_Constructor_WhenGridIsNull_ThrowArgumentNullException()
        {
            Grid<ushort> grid = null;
            int row = 0;
            int column = 0;
            ushort value = 4;

            Assert.Throws<ArgumentNullException>(() =>
            {
                GridCell<ushort> cell = new GridCell<ushort>(grid, row, column, value);
            });
        }

        [Test]
        [TestCase(-3)]
        [TestCase(GRID_HEIGHT + 5)]
        public void GridCell_Constructor_WhenRowIsNotInRange_ThrowArgumentOutOfRangeException(int row)
        {
            Grid<ushort> grid = new Grid<ushort>(GRID_WIDTH, GRID_HEIGHT);
            int column = 3;
            ushort value = 4;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                GridCell<ushort> cell = new GridCell<ushort>(grid, row, column, value);
            });
        }

        [Test]
        [TestCase(-7)]
        [TestCase(GRID_WIDTH + 2)]
        public void GridCell_Constructor_WhenColumnIsNotInRange_ThrowArgumentOutOfRangeException(int column)
        {
            Grid<ushort> grid = new Grid<ushort>(GRID_WIDTH, GRID_HEIGHT);
            int row = 2;
            ushort value = 7;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                GridCell<ushort> cell = new GridCell<ushort>(grid, row, column, value);
            });
        }

        [Test]
        public void GridCell_Constructor_WhenEverythingCorrect_DoesNotThrow()
        {
            Grid<ushort> grid = new Grid<ushort>(12);

            int row = 8;
            int col = 10;

            Assert.DoesNotThrow(() =>
            {
                GridCell<ushort> cell = new GridCell<ushort>(grid, row, col);
            });
        }

        [Test]
        [TestCaseSource(nameof(GridCellNeighboursDatasource))]
        public void GridCell_Neighbours_EnumerateCells_DoesNotThrow(int row, int column)
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT);

            GridCell<long> cell = grid[row, column];

            IEnumerable<GridCell<long>> neighbours = cell.Neighbours;
            foreach (GridCell<long> neighbour in neighbours) continue;
        }

        [Test]
        [TestCaseSource(nameof(GridCellNeighboursDatasource))]
        public void GridCell_Neighbours_AlwaysContainsNeighbours(int row, int column)
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT);

            GridCell<long> cell = grid[row, column];

            IEnumerable<GridCell<long>> neighbours = cell.Neighbours;

            bool hasNeighbours = neighbours.Any();

            Assert.IsTrue(hasNeighbours);
        }

        [Test]
        [TestCaseSource(nameof(GridCellNeighboursDatasource))]
        public void GridCell_Neighbours_AreAllNeighbour(int row, int column)
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT);

            GridCell<long> cell = grid[row, column];

            IEnumerable<GridCell<long>> neighbours = cell.Neighbours;

            bool areAllNeighbours = neighbours.All(neighbour =>
            {
                int deltaRow = cell.RowIndex - neighbour.RowIndex;
                int deltaCol = cell.ColumnIndex - neighbour.ColumnIndex;

                return deltaRow >= -1 && deltaRow <= 1 && deltaCol >= -1 && deltaCol <= 1;
            });

            Assert.IsTrue(areAllNeighbours);
        }

        [Test]
        [TestCaseSource(nameof(GridCellNeighboursDatasource))]
        public void GridCell_Neighbours_DoesNotContainSelf(int row, int column)
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT);

            GridCell<long> cell = grid[row, column];

            IEnumerable<GridCell<long>> neighbours = cell.Neighbours;

            bool containsSelf = neighbours.Contains(cell);

            Assert.IsFalse(containsSelf);
        }

        [Test]
        public void GridCell_Row_Index_Equals_RowIndex()
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT);

            GridCell<long> cell = grid[4, 8];

            GridRow<long> row = cell.Row;

            Assert.AreEqual(cell.RowIndex, row.Row);
        }

        [Test]
        public void GridCell_Column_Index_Equals_ColumnIndex()
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT);

            GridCell<long> cell = grid[4, 8];

            GridColumn<long> column = cell.Column;

            Assert.AreEqual(cell.ColumnIndex, column.Column);
        }

        #region DataSources
        private static IEnumerable<int[]> GridCellNeighboursDatasource
        {
            get
            {
                yield return new[] { 2, 8 };
                yield return new[] { 8, 2 };
                yield return new[] { 0, 2 };
                yield return new[] { 8, 0 };
                yield return new[] { GRID_HEIGHT - 1, 2 };
                yield return new[] { 8, GRID_WIDTH - 1 };
                yield return new[] { 0, 0 };
                yield return new[] { 0, GRID_WIDTH - 1 };
                yield return new[] { GRID_HEIGHT - 1, 0 };
                yield return new[] { GRID_HEIGHT - 1, GRID_WIDTH - 1 };
            }
        }
        #endregion
    }
}
