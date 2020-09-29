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
                menuThemes.MenuItems.Add(new MenuItem("Default", "1", DefaultMenuAction));
                menuThemes.MenuItems.Add(new MenuItem("Crimson", "2", DefaultMenuAction));
                menuThemes.MenuItems.Add(new MenuItem("Old School", "3", DefaultMenuAction));
                menuThemes.MenuItems.Add(new MenuItem("Commander", "4", DefaultMenuAction));
            
            var menuOptions = new Menu(MenuLevel.First);
            menuOptions.MenuItems.Add(new MenuItem("Graphics", "1", menuThemes.RunMenu));

            var menuMain = new Menu(MenuLevel.Root);
            menuMain.MenuItems.Add(new MenuItem("New Game: Player vs Player", "1", DefaultMenuAction));
            menuMain.MenuItems.Add(new MenuItem("New Game: Player vs AI", "2", DefaultMenuAction));
            menuMain.MenuItems.Add(new MenuItem("New Game: AI vs AI", "3", DefaultMenuAction));
            menuMain.MenuItems.Add(new MenuItem("Options", "O", menuOptions.RunMenu));
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