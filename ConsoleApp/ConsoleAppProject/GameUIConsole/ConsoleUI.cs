using System;
using GameEngine;

namespace GameUIConsole
{
    public static class ConsoleUi
    {
        private static readonly char[] Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static void DrawBoard(CellState[,] board)
        {
            var width = board.GetUpperBound(0) + 1; // x
            var height = board.GetUpperBound(1) + 1; // y

            for (var colIndex = 0; colIndex < width; colIndex++) Console.Write($"  {Alpha[colIndex]}  ");

            Console.WriteLine();
            for (var colIndex = 0; colIndex < width; colIndex++) Console.Write("+---+");

            Console.WriteLine();

            for (var rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (var colIndex = 0; colIndex < width; colIndex++)
                    Console.Write($"| {CellString(board[colIndex, rowIndex])} |");

                for (var colIndex = 11; colIndex == 11; colIndex++) Console.Write($"  {rowIndex + 1}");

                Console.WriteLine();
                for (var colIndex = 0; colIndex < width; colIndex++) Console.Write("+---+");

                Console.WriteLine();
            }
        }

        private static string CellString(CellState cellState)
        {
            switch (cellState)
            {
                case CellState.Empty: return " ";
                case CellState.O: return "1";
                case CellState.T: return "2";
            }

            return "";
        }
    }
}