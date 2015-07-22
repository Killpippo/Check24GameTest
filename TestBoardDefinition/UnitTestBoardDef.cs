using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBoardDefinition
{
    [TestClass]
    public class UnitTestBoardDef
    {
        private int[] ColorList = new int[] { 1, 2, 3 };

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DefinitionWrongWidth()
        {
            var oBoard = new Check24.Game.Board(0, 2, ColorList);

            oBoard = null;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DefinitionWrongHeight()
        {
            var oBoard = new Check24.Game.Board(2, -1, ColorList);

            oBoard = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DefinitionWrongColorsNull()
        {
            var oBoard = new Check24.Game.Board(2, 2, null);

            oBoard = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DefinitionWrongColorsNotenought()
        {
            var oBoard = new Check24.Game.Board(2, 2, new int[] {1});

            oBoard = null;
        }

        [TestMethod]
        public void CompleteDefinition()
        {
            var oBoard = new Check24.Game.Board(2, 2, ColorList);
        }
    }
}
