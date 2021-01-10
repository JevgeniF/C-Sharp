using System;
using Domain;

namespace GameUIConsole
{
    public static class ConsoleUi
    {
        private static readonly char[] Alpha = "ABCDEFGHIJKLMNOPQRST".ToCharArray();

        public static void DrawBoards((ECellState[,], ECellState[,]) boards, bool nextMoveByFirst)
        {
            if (nextMoveByFirst)
            {
                Console.WriteLine("===================> ENEMY'S FLEET DISLOCATION MAP <====================");
                DrawBoard(boards.Item1, false);
                Console.WriteLine("==================> YOUR FLEET DISLOCATION MAP, SIR <===================");
                DrawBoard(boards.Item2, true);
            }
            else
            {
                Console.WriteLine("===================> ENEMY'S FLEET DISLOCATION MAP <====================");
                DrawBoard(boards.Item2, false);
                Console.WriteLine("==================> YOUR FLEET DISLOCATION MAP, SIR <===================");
                DrawBoard(boards.Item1, true);
            }
        }

        public static void DrawBoard(ECellState[,] board, bool shipsOnBoard) {
            var width = board.GetUpperBound(0) + 1; // x
            var height = board.GetUpperBound(1) + 1; // y

            for (var col = 0; col < width; col++) Console.Write($"  {Alpha[col]}  ");

            Console.WriteLine();
            for (var col = 0;  col < width; col++) Console.Write("+---+");
            Console.WriteLine();
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                    Console.Write($"| {CellString(board[col, row], shipsOnBoard)} |");

                for (var col = 11; col == 11; col++) Console.Write($"  {row + 1}");

                Console.WriteLine();
                for (var col = 0; col < width; col++) Console.Write("+---+");

                Console.WriteLine();
            }
        }

        private static string CellString(ECellState cellState, bool shipsOnBoard)
        {
            return cellState switch
            {
                ECellState.Empty => " ",
                ECellState.Miss => "@",
                ECellState.Object => shipsOnBoard ? "S" : " ",
                ECellState.Wreck => "X",
                _ => " "
            };
        }
    }
}