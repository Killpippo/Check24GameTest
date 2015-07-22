using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBoardDefinition
{
    [TestClass]
    public class UnitTestBoardRuntime
    {
        private int[] ColorList = new int[] { 1, 2, 3, 4, 5 };
        private int[][] BoardValues;
        private int BoardWidth = 10;
        private int BoardHeight = 10;

        [TestInitialize]
        public void InitializeBoardColor()
        {
            BoardValues = new int[BoardWidth][];

            for ( int i=0; i<BoardWidth; i++ )
            {
                BoardValues[i] = new int[BoardHeight];

                // apply some colors
                for (int j = 0; j < BoardHeight; j++)
                    BoardValues[i][j] = ColorList[(ColorList.Length - 1) % (i * BoardHeight + j + 1)];
            }
        }

        [TestMethod]
        public void BoardIncompleteInitialization()
        {
            var oBoard = new Check24.Game.Board(BoardWidth, BoardHeight, ColorList);

            Assert.AreEqual(0, oBoard.Moves);
            Assert.AreEqual(Check24.Game.Board.eBoardStatus.NotInitialized, oBoard.BoardStatus);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void BoardIncompletePlay()
        {
            var oBoard = new Check24.Game.Board(BoardWidth, BoardHeight, ColorList);

            oBoard.ApplyColor(ColorList[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BoardSetColorMatrixNull()
        {
            var oBoard = new Check24.Game.Board(BoardWidth, BoardHeight, ColorList);

            oBoard.InitializeColors(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardSetColorMatrixUnexpectedWidthSize()
        {
            var oBoard = new Check24.Game.Board(BoardWidth, BoardHeight, ColorList);

            int [][] aBoardValues = new int[BoardWidth + 5][];

            for (int i = 0; i < BoardWidth; i++)
            {
                aBoardValues[i] = new int[BoardHeight];
            }

            oBoard.InitializeColors(aBoardValues);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardSetColorMatrixUnexpectedHeightSize()
        {
            var oBoard = new Check24.Game.Board(BoardWidth, BoardHeight, ColorList);

            int[][] aBoardValues = new int[BoardWidth][];

            for (int i = 0; i < BoardWidth; i++)
            {
                aBoardValues[i] = new int[BoardHeight + 5];
            }

            oBoard.InitializeColors(aBoardValues);
        }

        [TestMethod]
        public void BoardIncompleteInvalidPlayColor()
        {
            var oBoard = new Check24.Game.Board(BoardWidth, BoardHeight, ColorList);

            oBoard.InitializeColors(BoardValues);
        }
    }
}
