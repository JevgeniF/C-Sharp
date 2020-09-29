using System;
using MenuSystem;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // App name.

            Console.WriteLine("============================> BATTLESHIP <=============================");
            Console.WriteLine("");
            
            var menuThemes = new Menu(MenuLevel.Second);
                menuThemes.AddMenuItem(new MenuItem("Default", "1", DefaultMenuAction));
                menuThemes.AddMenuItem(new MenuItem("Crimson", "2", DefaultMenuAction));
                menuThemes.AddMenuItem(new MenuItem("Old School", "3", DefaultMenuAction));
                menuThemes.AddMenuItem(new MenuItem("Commander", "4", DefaultMenuAction));
            
            var menuOptions = new Menu(MenuLevel.First);
            menuOptions.AddMenuItem(new MenuItem("Graphics", "1", menuThemes.RunMenu));

            var menuMain = new Menu(MenuLevel.Root);
            menuMain.AddMenuItem(new MenuItem("New Game: Player vs Player", "1", DefaultMenuAction));
            menuMain.AddMenuItem(new MenuItem("New Game: Player vs AI", "2", DefaultMenuAction));
            menuMain.AddMenuItem(new MenuItem("New Game: AI vs AI", "3", DefaultMenuAction));
            menuMain.AddMenuItem(new MenuItem("Options", "4", menuOptions.RunMenu));
            menuMain.RunMenu();
            Console.WriteLine("");
            Console.WriteLine("                        ===> J.Fenko(c) 2020 <===");
        }

        static void DefaultMenuAction()
        {
            Console.WriteLine("Not implemented yet.");
        }
    }
}