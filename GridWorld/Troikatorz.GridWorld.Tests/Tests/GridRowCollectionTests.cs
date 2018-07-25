using NUnit.Framework;
using System;

namespace Troikatorz.GridWorld.Tests
{
    [TestFixture(TestOf = typeof(GridRowCollection<>))]
    public class GridRowCollectionTests
    {
        private const int GRID_WIDTH = 18;
        private const int GRID_HEIGHT = 24;

        [Test]
        public void GridRowCollection_Constructor_WhenGridIsNull_ThrowArgumentNullException()
        {
            Grid<string> grid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                GridRowCollection<string> grc = new GridRowCollection<string>(grid);
            });
        }

        [Test]
        public void GridRowCollection_Constructor_WhenArgumentIsCorrect_DoesNotThrow()
        {
            Grid<string> grid = new Grid<string>(GRID_WIDTH, GRID_HEIGHT, "My taylor is rich!");

            Assert.DoesNotThrow(() =>
            {
                GridRowCollection<string> grc = new GridRowCollection<string>(grid);
            });
        }

        [Test]
        public void GridRowCollection_EnumerateRows_DoesNotThrow()
        {
            Grid<string> grid = new Grid<string>(GRID_WIDTH, GRID_HEIGHT, "Hello world!");

            GridRowCollection<string> grc = new GridRowCollection<string>(grid);
            Assert.DoesNotThrow(() =>
            {
                foreach (GridRow<string> gridRow in grc) continue;
            });
        }

        [Test]
        [TestCase(-2)]
        [TestCase(GRID_HEIGHT)]
        [TestCase(int.MaxValue)]
        public void GridRowCollection_Index_WhenArgumentOutOfRange_ThrowIndexOutOfRangeException(int col)
        {
            Grid<char> grid = new Grid<char>(GRID_WIDTH, GRID_HEIGHT);

            GridRowCollection<char> grc = new GridRowCollection<char>(grid);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                GridRow<char> row = grc[col];
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(GRID_HEIGHT - 1)]
        public void GridRowCollection_Index_WhenArgumentIsCorrect_DoesNotThrow(int col)
        {
            Grid<char> grid = new Grid<char>(GRID_WIDTH, GRID_HEIGHT);

            GridRowCollection<char> grc = new GridRowCollection<char>(grid);
            Assert.DoesNotThrow(() =>
            {
                GridRow<char> row = grc[col];
            });
        }
    }
}
