using NUnit.Framework;
using System;
using System.Linq;

namespace Troikatorz.GridWorld.Tests
{
    [TestFixture(TestOf = typeof(GridColumnCollection<>))]
    public class GridColumnCollectionTests
    {
        private const int GRID_WIDTH = 18;
        private const int GRID_HEIGHT = 24;

        [Test]
        public void GridColumnCollection_Constructor_WhenGridIsNull_ThrowArgumentNullException()
        {
            Grid<string> grid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                GridColumnCollection<string> gcc = new GridColumnCollection<string>(grid);
            });
        }

        [Test]
        public void GridColumnCollection_Constructor_WhenArgumentIsCorrect_DoesNotThrow()
        {
            Grid<string> grid = new Grid<string>(GRID_WIDTH, GRID_HEIGHT, "My taylor is rich!");

            Assert.DoesNotThrow(() =>
            {
                GridColumnCollection<string> gcc = new GridColumnCollection<string>(grid);
            });
        }

        [Test]
        public void GridColumnCollection_EnumerateColumns_DoesNotThrow()
        {
            Grid<string> grid = new Grid<string>(GRID_WIDTH, GRID_HEIGHT, "Hello world!");

            GridColumnCollection<string> gcc = new GridColumnCollection<string>(grid);
            Assert.DoesNotThrow(() =>
            {
                foreach (GridColumn<string> gridCol in gcc) continue;
            });
        }

        [Test]
        [TestCase(-2)]
        [TestCase(GRID_WIDTH)]
        [TestCase(int.MaxValue)]
        public void GridColumnCollection_Index_WhenArgumentOutOfRange_ThrowIndexOutOfRangeException(int col)
        {
            Grid<char> grid = new Grid<char>(GRID_WIDTH, GRID_HEIGHT);

            GridColumnCollection<char> gcc = new GridColumnCollection<char>(grid);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                GridColumn<char> column = gcc[col];
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(GRID_WIDTH - 1)]
        public void GridColumnCollection_Index_WhenArgumentIsCorrect_DoesNotThrow(int col)
        {
            Grid<char> grid = new Grid<char>(GRID_WIDTH, GRID_HEIGHT);

            GridColumnCollection<char> gcc = new GridColumnCollection<char>(grid);
            Assert.DoesNotThrow(() =>
            {
                GridColumn<char> column = gcc[col];
            });
        }

        [Test]
        public void GridColumnCollection_Columns_Count_Equals_Grid_Width()
        {
            Grid<ushort> grid = new Grid<ushort>(GRID_WIDTH, GRID_HEIGHT);

            GridColumnCollection<ushort> gcc = new GridColumnCollection<ushort>(grid);

            int columnCount = gcc.Count();
            int gridWidth = grid.Width;

            Assert.AreEqual(columnCount, gridWidth);
        }
    }
}
