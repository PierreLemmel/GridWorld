using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Troikatorz.GridWorld.Tests
{
    [TestFixture(TestOf = typeof(Grid<>))]
    public class GridTests
    {
        #region Array Constructor
        [Test]
        public void GridArrayConstructor_WhenCells_AreEmpty_Throw_ArgumentNullException()
        {
            int[,] cells = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Grid<int> grid = new Grid<int>(cells);
            });
        }

        [Test]
        public void GridArrayConstructor_WhenCellsWidthIsZero_Throw_ArgumentException()
        {
            int[,] cells = new int[0, 18];

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<int> grid = new Grid<int>(cells);
            });
        }

        [Test]
        public void GridArrayConstructor_WhenCellsHeightIsZero_Throw_ArgumentNullException()
        {
            int[,] cells = new int[,]
            {
                { },
                { },
                { },
                { },
                { }
            };

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<int> grid = new Grid<int>(cells);
            });
        }

        [Test]
        public void GridArrayConstructor_WhenCellsIsCorrect_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                int[,] cells = new int[,]
                {
                    { 1 , 2 , 3 , 4  },
                    { 5 , 6 , 7 , 8  },
                    { 9 , 10, 11, 12 },
                    { 13, 14, 15, 16 },
                    { 17, 18, 19, 20 }
                };

                Grid<int> grid = new Grid<int>(cells);
            });
        }

        [Test]
        public void GridArrayConstructor_GridDimensions_EqualsToArrays()
        {
            const int CELLS_WIDTH = 4;
            const int CELLS_HEIGHT = 5;

            int[,] cells = new int[CELLS_HEIGHT, CELLS_WIDTH]
            {
                { 1 , 2 , 3 , 4  },
                { 5 , 6 , 7 , 8  },
                { 9 , 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 17, 18, 19, 20 }
            };

            Grid<int> grid = new Grid<int>(cells);

            Assert.Multiple(() =>
            {
                int gridWidth = grid.Width;
                int gridHeight = grid.Height;

                Assert.AreEqual(CELLS_WIDTH, gridWidth);
                Assert.AreEqual(CELLS_HEIGHT, gridHeight);
            });
        }

        [Test]
        public void GridArrayConstructor_GridValues_EqualsToArrays()
        {
            const int CELLS_WIDTH = 4;
            const int CELLS_HEIGHT = 5;

            int[,] cells = new int[CELLS_HEIGHT, CELLS_WIDTH]
            {
                { 1 , 2 , 3 , 4  },
                { 5 , 6 , 7 , 8  },
                { 9 , 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 17, 18, 19, 20 }
            };

            Grid<int> grid = new Grid<int>(cells);

            for (int row = 0; row < CELLS_HEIGHT; row++)
            {
                for (int col = 0; col < CELLS_WIDTH; col++)
                {
                    int cellValue = cells[row, col];
                    int gridValue = grid[row, col].Value;
                }
            }
        }
        #endregion

        #region Width/Height Constructor
        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void GridWidthHeightConstructor_WhenWidth_IsNegativeOrNull_ThrowArgumentException(int width)
        {
            int height = 10;

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<ushort> grid = new Grid<ushort>(width, height);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-7)]
        public void GridWidthHeightConstructor_WhenHeight_IsNegativeOrNull_ThrowArgumentException(int height)
        {
            int width = 10;

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<ushort> grid = new Grid<ushort>(width, height);
            });
        }

        [Test]
        public void GridWidthHeightConstructor_ValidValues_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                int width = 4;
                int height = 5;

                Grid<string> grid = new Grid<string>(width, height);
            });
        }

        [Test]
        public void GridWidthHeightConstructor_ValuesEqualsToDefault_UShort()
        {
            int width = 4;
            int height = 5;

            Grid<ushort> grid = new Grid<ushort>(width, height);

            foreach(GridCell<ushort> cell in grid)
            {
                ushort cellValue = cell.Value;
                Assert.AreEqual(cellValue, default(ushort));
            }
        }

        [Test]
        public void GridWidthHeightConstructor_ValuesEqualsToDefault_String()
        {
            int width = 4;
            int height = 5;

            Grid<string> grid = new Grid<string>(width, height);

            foreach (GridCell<string> cell in grid)
            {
                string cellValue = cell.Value;
                Assert.AreEqual(cellValue, default(string));
            }
        }
        #endregion

        #region Width/Height/DefaultValue Constructor
        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void GridWidthHeightDefaultValueConstructor_WhenWidth_IsNegativeOrNull_ThrowArgumentException(int width)
        {
            int height = 10;
            ushort defaultValue = 5;

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<ushort> grid = new Grid<ushort>(width, height, defaultValue);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-7)]
        public void GridWidthHeightDefaultValueConstructor_WhenHeight_IsNegativeOrNull_ThrowArgumentException(int height)
        {
            int width = 10;
            ushort defaultValue = 5;

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<ushort> grid = new Grid<ushort>(width, height, defaultValue);
            });
        }

        [Test]
        public void GridWidthHeightDefaultValueConstructor_ValidValues_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                int width = 4;
                int height = 5;

                string defaultValue = "Hello!";

                Grid<string> grid = new Grid<string>(width, height, defaultValue);
            });
        }

        [Test]
        public void GridWidthHeightDefaultConstructor_ValuesEqualsToDefault_UShort()
        {
            int width = 4;
            int height = 5;

            ushort defaultValue = 13;

            Grid<ushort> grid = new Grid<ushort>(width, height, defaultValue);

            foreach (GridCell<ushort> cell in grid)
            {
                ushort cellValue = cell.Value;
                Assert.AreEqual(cellValue, defaultValue);
            }
        }

        [Test]
        public void GridWidthHeightDefaultConstructor_ValuesEqualsToDefault_String()
        {
            int width = 4;
            int height = 5;

            string defaultValue = "Hello!";

            Grid<string> grid = new Grid<string>(width, height, defaultValue);

            foreach (GridCell<string> cell in grid)
            {
                string cellValue = cell.Value;
                Assert.AreEqual(cellValue, defaultValue);
            }
        }
        #endregion

        #region Size Constructor
        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void GridSizeConstructor_WhenSize_IsNegativeOrNull_ThrowArgumentException(int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Grid<ushort> grid = new Grid<ushort>(size);
            });
        }

        [Test]
        public void GridSizeConstructor_ValidValues_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                int size = 10;

                Grid<string> grid = new Grid<string>(size);
            });
        }

        [Test]
        public void GridSizeConstructor_ValuesEqualsToDefault_UShort()
        {
            int size = 14;

            Grid<ushort> grid = new Grid<ushort>(size);

            foreach (GridCell<ushort> cell in grid)
            {
                ushort cellValue = cell.Value;
                Assert.AreEqual(cellValue, default(ushort));
            }
        }

        [Test]
        public void GridSizeConstructor_ValuesEqualsToDefault_String()
        {
            int size = 14;

            Grid<string> grid = new Grid<string>(size);

            foreach (GridCell<string> cell in grid)
            {
                string cellValue = cell.Value;
                Assert.AreEqual(cellValue, default(string));
            }
        }
        #endregion

        #region Size/DefaultValue Constructor
        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void GridSizeDefaultValueConstructor_WhenSize_IsNegativeOrNull_ThrowArgumentException(int size)
        {
            ushort defaultValue = 18;

            Assert.Throws<ArgumentException>(() =>
            {
                Grid<ushort> grid = new Grid<ushort>(size, defaultValue);
            });
        }

        [Test]
        public void GridSizeDefaultValueConstructor_ValidValues_DoesNotThrow()
        {
            ushort defaultValue = 14;

            Assert.DoesNotThrow(() =>
            {
                int size = 10;

                Grid<string> grid = new Grid<string>(size, defaultValue);
            });
        }

        [Test]
        public void GridSizeDefaultValueConstructor_ValuesEqualsToDefault_UShort()
        {
            int size = 14;
            ushort defaultValue = 23;

            Grid<ushort> grid = new Grid<ushort>(size, defaultValue);

            foreach (GridCell<ushort> cell in grid)
            {
                ushort cellValue = cell.Value;
                Assert.AreEqual(cellValue, defaultValue);
            }
        }

        [Test]
        public void GridSizeDefaultValueConstructor_ValuesEqualsToDefault_String()
        {
            int size = 14;
            string defaultValue = "World!";

            Grid<string> grid = new Grid<string>(size, defaultValue);

            foreach (GridCell<string> cell in grid)
            {
                string cellValue = cell.Value;
                Assert.AreEqual(cellValue, defaultValue);
            }
        }
        #endregion

        #region Enumerable
        [Test]
        public void Grid_EnumerateCells_DoesNotThrow()
        {
            const int CELLS_WIDTH = 4;
            const int CELLS_HEIGHT = 5;

            int[,] cells = new int[CELLS_HEIGHT, CELLS_WIDTH]
            {
                { 1 , 2 , 3 , 4  },
                { 5 , 6 , 7 , 8  },
                { 9 , 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 17, 18, 19, 20 }
            };

            Grid<int> grid = new Grid<int>(cells);

            Assert.DoesNotThrow(() =>
            {
                foreach (GridCell<int> cell in grid) continue;
            });
        }
        #endregion

        #region Cells
        [Test]
        public void Grid_GridCells_IndexAreCorrect()
        {
            const int CELLS_WIDTH = 4;
            const int CELLS_HEIGHT = 5;

            int[,] cells = new int[CELLS_HEIGHT, CELLS_WIDTH]
            {
                { 1 , 2 , 3 , 4  },
                { 5 , 6 , 7 , 8  },
                { 9 , 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 17, 18, 19, 20 }
            };

            Grid<int> grid = new Grid<int>(cells);

            for (int row = 0; row < CELLS_HEIGHT; row++)
            {
                for (int col = 0; col < CELLS_WIDTH; col++)
                {
                    GridCell<int> gridCell = grid[row, col];

                    int cellRow = gridCell.RowIndex;
                    int cellColumn = gridCell.ColumnIndex;

                    Assert.AreEqual(row, cellRow);
                    Assert.AreEqual(col, cellColumn);
                }
            }
        }

        private const int GRID_WIDTH = 10;
        private const int GRID_HEIGHT = 14;

        [Test]
        [TestCase(-2, 4)]
        [TestCase(3, -8)]
        [TestCase(GRID_HEIGHT, 5)]
        [TestCase(0, GRID_WIDTH + 2)]
        public void Grid_Index_WhenArgumentOutOfRange_ThrowIndexOutOfRangeException(int row, int col)
        {
            Grid<decimal> grid = new Grid<decimal>(GRID_WIDTH, GRID_HEIGHT, -14.0m);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                GridCell<decimal> cell = grid[row, col];
            });
        }

        [Test]
        [TestCaseSource(nameof(GridIndexCorrectValuesDataSource))]
        public void Grid_Index_WhenArgumenIsCorrect_DoesNotThrow(int row, int col)
        {
            Grid<decimal> grid = new Grid<decimal>(GRID_WIDTH, GRID_HEIGHT, 28.5m);

            Assert.DoesNotThrow(() =>
            {
                GridCell<decimal> cell = grid[row, col];
            });
        }

        [Test]
        [TestCaseSource(nameof(GridIndexCorrectValuesDataSource))]
        public void Grid_Index_MultipleAccess_ReturnsSameCell(int row, int col)
        {
            Grid<float> grid = new Grid<float>(GRID_WIDTH, GRID_HEIGHT, 3.14f);

            GridCell<float> cell1 = grid[row, col];
            GridCell<float> cell2 = grid[row, col];

            Assert.AreEqual(cell1, cell2);
        }

        [Test]
        [TestCaseSource(nameof(GridCellsOnSameRowDataSource))]
        public void Grid_Cells_OnSameRow_Share_Row(int row, int col1, int col2)
        {
            Grid<object> grid = new Grid<object>(GRID_WIDTH, GRID_HEIGHT, "Why not?");

            GridCell<object> cell1 = grid[row, col1];
            GridRow<object> row1 = cell1.Row;

            GridCell<object> cell2 = grid[row, col2];
            GridRow<object> row2 = cell2.Row;

            Assert.AreEqual(row1, row2);
        }

        [Test]
        [TestCaseSource(nameof(GridCellsOnSameColumnDataSource))]
        public void Grid_Cells_OnSameColumn_Share_Column(int column, int row1, int row2)
        {
            Grid<object> grid = new Grid<object>(GRID_WIDTH, GRID_HEIGHT, "Why not?");

            GridCell<object> cell1 = grid[row1, column];
            GridColumn<object> col1 = cell1.Column;

            GridCell<object> cell2 = grid[row2, column];
            GridColumn<object> col2 = cell2.Column;

            Assert.AreEqual(col1, col2);
        }
        #endregion

        #region DataSources
        private static IEnumerable<int[]> GridIndexCorrectValuesDataSource
        {
            get
            {
                yield return new[] { 0, 0 };
                yield return new[] { 2, 8 };
                yield return new[] { 0, GRID_WIDTH - 1 };
                yield return new[] { GRID_HEIGHT - 1, 0 };
                yield return new[] { GRID_HEIGHT - 1, GRID_WIDTH - 1 };
            }
        }

        private static IEnumerable<int[]> GridCellsOnSameRowDataSource
        {
            get
            {
                yield return new int[] { 3, 2, 8 };
                yield return new int[] { 0, 0, GRID_WIDTH - 1 };
                yield return new int[] { GRID_HEIGHT - 1, 2, 8 };
                yield return new int[] { GRID_HEIGHT - 1, 0, GRID_WIDTH - 1 };
            }
        }

        private static IEnumerable<int[]> GridCellsOnSameColumnDataSource
        {
            get
            {
                yield return new int[] { 5, 4, 7 };
                yield return new int[] { 0, 0, GRID_HEIGHT - 1 };
                yield return new int[] { GRID_WIDTH - 1, 4, 7 };
                yield return new int[] { GRID_WIDTH - 1, 0, GRID_HEIGHT - 1 };
            }
        }
        #endregion
    }
}