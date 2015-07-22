using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check24.Game
{
    public class Board
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int[] ColorList { get; private set; }

        public Board( int _iWidth, int _iHeight, int [] _aColorList )
        {
            if (_iWidth < 1)
                throw new IndexOutOfRangeException("Board width too small");

            if (_iHeight < 1)
                throw new IndexOutOfRangeException("Board heght too small");

            if (_aColorList == null || _aColorList.Length < 2)
                throw new ArgumentOutOfRangeException("Not enought colors specified");
        }
    }
}
