using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Check24.Game
{
    public class Board
    {
        #region Enum and constants

        /// <summary>
        /// Definition of the board status
        /// </summary>
        public enum eBoardStatus
        {
            /// <summary>
            /// The board has not initialized propery
            /// </summary>
            NotInitialized,
            /// <summary>
            /// The game is still in progress
            /// </summary>
            GameInProgress,
            /// <summary>
            /// The game has finished, all the cells have the same color
            /// </summary>
            Completed
        }

        private const int InvalidColor = -1;

        #endregion

        #region Members

        /// <summary>
        /// Definition of the colors for this round
        /// </summary>
        public SortedSet<int> ColorList { get; private set; }

        /// <summary>
        /// Cell colors
        /// </summary>
        private int[][] Cells { get; set; }

        /// <summary>
        /// Board size based on constructor params
        /// </summary>
        public int Width { get; private set; }
        public int Height { get; private set; }

        /// <summary>
        /// Number of action done by the player
        /// </summary>
        public int Moves { get; private set; }

        /// <summary>
        /// Current board and game status
        /// </summary>
        public eBoardStatus BoardStatus { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_iWidth">Must be positive and more than two</param>
        /// <param name="_iHeight">Must be positive and more than two</param>
        /// <param name="_aColorList">Must contains more than two RGB color value</param>
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
                // invalid color
                if (_aColorList[i] <= InvalidColor)
                    throw new ArgumentException("Color must be an ARGB positive value");

                if (ColorList.Add(_aColorList[i]) == false)
                    throw new ArgumentException("Color duplication");
            }

            Width = _iWidth;
            Height = _iHeight;

            Cells = new int[Width][];
            for ( int h=0; h<Width; h++ )
                Cells[h] = new int[Height];

            // initialize to undefined color, and external entity have to setup the board
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Cells[i][j] = InvalidColor;

            // initialize other members
            Moves = 0;
            BoardStatus = eBoardStatus.NotInitialized;
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
        /// Apply the color of the celss before start the game
        /// </summary>
        /// <param name="_aCellColor"></param>
        public void InitializeColors( int [][] _aCellColor)
        {
            if (_aCellColor == null)
                throw new ArgumentNullException("Invalid cell color params");

            if (_aCellColor.Length != Width || _aCellColor[0].Length != Height)
                throw new ArgumentOutOfRangeException("Cell color matrix wrong size");

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (!ColorList.Contains( _aCellColor[i][j] ))
                        throw new ArgumentOutOfRangeException("Invalid color");
 
                    Cells[i][j] = _aCellColor[i][j];
                }
            }

            BoardStatus = eBoardStatus.GameInProgress;
        }

        /// <summary>
        /// Apply color to the first cell
        /// </summary>
        /// <param name="_oColor"></param>
        public void ApplyColor( int _iColor )
        {
            // not initialized
            if (BoardStatus == eBoardStatus.NotInitialized)
                throw new ArgumentException("Board has not been initialized");

            if (!ColorList.Contains(_iColor))
                throw new ArgumentOutOfRangeException("Invalid color");

            // color didn't change
            if (Cells[0][0] == _iColor) return;

            Moves++;

            throw new NotImplementedException("Apply color selected: Not implemented yet");

            // TODO
            // per row colors
            // verifica board cells status
            // CheckGameStatus();
        }

        /// <summary>
        /// Verify if the game has finished or still in progress, apply the change in BoardStatusMember
        /// </summary>
        private void CheckGameStatus()
        {
            // ignore action if not initialized
            if (BoardStatus == eBoardStatus.NotInitialized) return;

            throw new NotImplementedException("Verify game status: Not implemented yet");
        }
    }
}
