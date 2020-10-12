using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using GameEngine;

namespace GameUIConsole
{
    public static class ConsoleUI
    {
        static char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public static void DrawBoard(CellState[,] board)
        {
            var width = board.GetUpperBound(0) + 1; // x
            var height = board.GetUpperBound(1) + 1; // y
            
            
            for (int colIndex = 0; colIndex < width; colIndex++)
            {
                Console.Write($"  {_alpha[colIndex]}  ");
            }
            Console.WriteLine();
            for (int colIndex = 0; colIndex < width; colIndex++)
            {
                Console.Write($"+---+");
            }
            Console.WriteLine();
           
            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (int colIndex = 0; colIndex < width; colIndex++)
                {
                    Console.Write($"| {CellString(board[colIndex, rowIndex])} |");
                }
                for (int colIndex = 11; colIndex == 11; colIndex++)
                {
                    Console.Write($"  {rowIndex + 1}");
                }
                Console.WriteLine();
                for (int colIndex = 0; colIndex < width; colIndex++)
                {
                    Console.Write($"+---+");
                }
                Console.WriteLine();
            }
        }

        public static string CellString(CellState cellState)
        {
            switch (cellState)
            {
                case CellState.Empty: return " ";
                case CellState.X: return "X";
            }

            return "";
        }
    }
}