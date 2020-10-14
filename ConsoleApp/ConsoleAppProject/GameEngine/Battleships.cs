using System;
using System.Collections;

namespace GameEngine
{
    public class Battleships
    {
        public static int Width = 10;
        public static string MoveCoordinates = "";
        private readonly CellState[,] _board = new CellState[Width, Width];
        private static bool _nextMoveByFirst = true;

        public Array[] GetBoards()
        {
            var res1 = new CellState[Width, Width];
            Array.Copy(_board, res1, _board.Length);
            var res2 = new CellState[Width, Width];
            Array.Copy(_board, res2, _board.Length);
            var resses = new[] {res1, res2};
            return resses;
        }

        public bool NextMoveByFirst => _nextMoveByFirst;

        public bool MakeAMove(CellState[,] board)
        {
            int attackCol = (char.ToUpper(MoveCoordinates[0]) - 65);
            int attackRow = Int32.Parse(MoveCoordinates.Substring(1)) - 1;
            if (attackCol >= Width || attackRow >= Width)
            {
                Console.WriteLine("Wrong move! Try again!");
            } else if (board[attackCol, attackRow] == CellState.Empty)
            {
                board[attackCol, attackRow] = _nextMoveByFirst ? CellState.O : CellState.T;
                _nextMoveByFirst = !_nextMoveByFirst;
                return true;
            }
            return false;
        }
    }
}