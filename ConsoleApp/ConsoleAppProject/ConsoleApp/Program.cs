using System;
using MenuSystem;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main()
        {
            // App name.

            Console.WriteLine("=============================> BATTLESHIP <=============================");
            Console.WriteLine("");
            var menu = new Menu();
            menu.RunMenu();
            Console.WriteLine("");
            Console.WriteLine("=============================> J.Fenko(c) <=============================");
        }
    }
}