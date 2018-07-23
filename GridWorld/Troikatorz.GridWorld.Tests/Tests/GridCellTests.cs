using NUnit.Framework;
using System;

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
    }
}
