using NUnit.Framework;
using System;

namespace Troikatorz.GridWorld.Tests
{
    [TestFixture(TestOf = typeof(GridRow<>))]
    public class GridRowTests
    {
        private const int GRID_WIDTH = 10;
        private const int GRID_HEIGHT = 14;

        [Test]
        public void GridRow_Constructor_WhenGridIsNull_ThrowArgumentNullException()
        {
            Grid<string> grid = null;
            int row = 4;

            Assert.Throws<ArgumentNullException>(() =>
            {
                GridRow<string> gridRow = new GridRow<string>(grid, row);
            });
        }

        [Test]
        [TestCase(-8)]
        [TestCase(GRID_WIDTH + 1)]
        public void GridRow_Constructor_WhenRowIsNotInRange_ThrowArgumentOutOfRangeException(int row)
        {
            Grid<ushort> grid = new Grid<ushort>(4, GRID_WIDTH);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                GridRow<ushort> gridRow = new GridRow<ushort>(grid, row);
            });
        }

        [Test]
        public void GridRow_Constructor_WhenEverythingCorrect_DoesNotThrow()
        {
            Grid<ushort> grid = new Grid<ushort>(12);

            int row = 8;

            Assert.DoesNotThrow(() =>
            {
                GridRow<ushort> gridRow = new GridRow<ushort>(grid, row);
            });
        }

        [Test]
        public void GridRow_EnumerateCells_DoesNotThrow()
        {
            Grid<ushort> grid = new Grid<ushort>(12);
            int row = 8;

            GridRow<ushort> gridRow = new GridRow<ushort>(grid, row);

            Assert.DoesNotThrow(() =>
            {
                foreach (GridCell<ushort> cell in gridRow) continue;
            });
        }

        [Test]
        [TestCase(-2)]
        [TestCase(GRID_WIDTH)]
        [TestCase(GRID_WIDTH + 5)]
        [TestCase(int.MaxValue)]
        public void GridRow_Index_WhenArgumentOutOfRange_ThrowIndexOutOfRangeException(int col)
        {
            Grid<ushort> grid = new Grid<ushort>(GRID_WIDTH, GRID_HEIGHT);
            int row = 8;

            GridRow<ushort> gridRow = new GridRow<ushort>(grid, row);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                GridCell<ushort> cell = gridRow[col];
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(GRID_WIDTH - 1)]
        public void GridRow_Index_WhenArgumenIsCorrect_DoesNotThrow(int col)
        {
            Grid<ushort> grid = new Grid<ushort>(GRID_WIDTH, GRID_HEIGHT);
            int row = 8;

            GridRow<ushort> gridRow = new GridRow<ushort>(grid, row);

            Assert.DoesNotThrow(() =>
            {
                GridCell<ushort> cell = gridRow[col];
            });
        }
    }
}
