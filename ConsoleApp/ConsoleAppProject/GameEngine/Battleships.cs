using System;
using System.Data.Common;

namespace GameEngine
{

    public class Battleships
    {
        public static int width = 10;
        private readonly CellState[,] _board = new CellState[width,width];

        public CellState[,] GetBoard()
        {
            var res = new CellState[width, width];
            Array.Copy(_board, res, _board.Length);
            return res;
        }
        
    }
}