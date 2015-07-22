using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check24.Game
{
    public class Board
    {
        #region Members

        public SortedSet<int> ColorList { get; private set; }

        private int[,] Cells { get; set; }

        public int Width { get { return Cells.Length; } }
        public int Height { get { return Cells.GetLength(0); } }

        #endregion

        #region Constructor

        public Board( int _iWidth, int _iHeight, int [] _aColorList )
        {
            if (_iWidth < 1)
                throw new IndexOutOfRangeException("Board width too small");

            if (_iHeight < 1)
                throw new IndexOutOfRangeException("Board heght too small");

            if (_aColorList == null || _aColorList.Length < 2)
                throw new ArgumentOutOfRangeException("Not enought colors specified");

            // assign color, check every color is different
            ColorList = new SortedSet<int>();
            for ( int i=0; i < _aColorList.Length; i++ )
            {
                if (ColorList.Add(_aColorList[i]) == false)
                    throw new ArgumentException("Color duplication");
            }
            
            Cells = new int[_iWidth, _iHeight];
        }

        #endregion

        /// <summary>
        /// Check board cocordinates are in range
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void CellCoordCheck( int i, int j )
        {
            if (i < 0 || i > Width)
                throw new IndexOutOfRangeException("Undefined row");
            if (j < 0 || j > Height)
                throw new IndexOutOfRangeException("Undefined height");
        }

        /// <summary>
        /// Set/Get board cell color
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int this[int i,int j]
        {
            get
            {
                CellCoordCheck(i,j);

                return Cells[i, j];
            }

            set
            {
                CellCoordCheck(i, j);

                if (!ColorList.Contains(value))
                    throw new ArgumentOutOfRangeException("Invalid color");

                Cells[i, j] = value;
            }
        }
    }
}
