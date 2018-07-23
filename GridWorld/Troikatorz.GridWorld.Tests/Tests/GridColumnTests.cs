using NUnit.Framework;
using System;

namespace Troikatorz.GridWorld.Tests
{
    [TestFixture(TestOf = typeof(GridColumn<>))]
    public class GridColumnTests
    {
        private const int GRID_WIDTH = 10;
        private const int GRID_HEIGHT = 14;

        [Test]
        public void GridColumn_Constructor_WhenGridIsNull_ThrowArgumentNullException()
        {
            Grid<string> grid = null;
            int column = 4;

            Assert.Throws<ArgumentNullException>(() =>
            {
                GridColumn<string> gridCol = new GridColumn<string>(grid, column);
            });
        }

        [Test]
        [TestCase(-8)]
        [TestCase(GRID_HEIGHT + 1)]
        public void GridColumn_Constructor_WhenRowIsNotInRange_ThrowArgumentOutOfRangeException(int column)
        {
            Grid<ushort> grid = new Grid<ushort>(4, GRID_HEIGHT);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                GridColumn<ushort> gridCol = new GridColumn<ushort>(grid, column);
            });
        }

        [Test]
        public void GridColumn_Constructor_WhenEverythingCorrect_DoesNotThrow()
        {
            Grid<ushort> grid = new Grid<ushort>(12);

            int col = 8;

            Assert.DoesNotThrow(() =>
            {
                GridColumn<ushort> gridCol = new GridColumn<ushort>(grid, col);
            });
        }

        [Test]
        public void GridColumn_EnumerateCells_DoesNotThrow()
        {
            Grid<ushort> grid = new Grid<ushort>(12);
            int col = 8;

            GridColumn<ushort> gridCol = new GridColumn<ushort>(grid, col);

            Assert.DoesNotThrow(() =>
            {
                foreach (GridCell<ushort> cell in gridCol) continue;
            });
        }

        [Test]
        [TestCase(-2)]
        [TestCase(GRID_HEIGHT)]
        [TestCase(GRID_HEIGHT + 4)]
        [TestCase(int.MaxValue)]
        public void GridColumn_Index_WhenArgumentOutOfRange_ThrowIndexOutOfRangeException(int row)
        {
            Grid<ushort> grid = new Grid<ushort>(GRID_WIDTH, GRID_HEIGHT);
            int col = 8;

            GridColumn<ushort> gridCol = new GridColumn<ushort>(grid, col);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                GridCell<ushort> cell = gridCol[row];
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(GRID_HEIGHT - 1)]
        public void GridColumn_Index_WhenArgumenIsCorrect_DoesNotThrow(int row)
        {
            Grid<long> grid = new Grid<long>(GRID_WIDTH, GRID_HEIGHT, 666L);
            int col = 8;

            GridColumn<long> gridCol = new GridColumn<long>(grid, col);

            Assert.DoesNotThrow(() =>
            {
                GridCell<long> cell = gridCol[row];
            });
        }
    }
}
