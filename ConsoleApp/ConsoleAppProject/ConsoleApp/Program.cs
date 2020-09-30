using System;
using MenuSystem;

namespace ConsoleApp
{
    internal static class Program
    {
        static void Main()
        {
            // App Header.
            Console.WriteLine("============================> BATTLESHIP <=============================");
            Console.WriteLine("");

            // Menu options "constructor"
            var menuGraphics = new Menu(MenuLevel.Secondary);
            menuGraphics.AddMenuItem(new MenuItem("Default", "1", ThemeReset));
            menuGraphics.AddMenuItem(new MenuItem("Old School", "2", ThemeChanger, "black", "green"));

            var menuOptions = new Menu(MenuLevel.First);
            menuOptions.AddMenuItem(new MenuItem("Graphics", "1", menuGraphics.RunMenu));

            var menuMain = new Menu(MenuLevel.Root);
            menuMain.AddMenuItem(new MenuItem("New Game: Player vs Player", "1", DefaultMenuAction));
            menuMain.AddMenuItem(new MenuItem("New Game: Player vs AI", "2", DefaultMenuAction));
            menuMain.AddMenuItem(new MenuItem("New Game: AI vs AI", "3", DefaultMenuAction));
            menuMain.AddMenuItem(new MenuItem("Options", "4", menuOptions.RunMenu));

            menuMain.RunMenu();
            
            Console.WriteLine("");
            
            //App footer.
            Console.WriteLine("===> (c) 2020 <===");
        }

        static string DefaultMenuAction() //Default action for not implemented menu functions
        {
            Console.WriteLine("Not implemented yet.");
            return "";
        }

        static string ThemeReset() //Dedicated action for reversion of color theme back to default console colors.
        {
            Console.ResetColor();
            Console.WriteLine("Default Theme Set!");
            return "";
        }

        static string ThemeChanger() // Action for Menu "Theme" items in Options/Graphics
        {
            var background = MenuItem.Background;
            var foreground = MenuItem.Foreground;

            ConsoleColor consoleColorBack;
            try
            {
                consoleColorBack = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), background!, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Color!");
                throw;
            }

            Console.BackgroundColor = consoleColorBack;

            ConsoleColor consoleColorFront;
            try
            {
                consoleColorFront = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), foreground!, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Color!");
                throw;
            }

            Console.ForegroundColor = consoleColorFront;
            Console.WriteLine("Theme Changed");
            return "";
        }
    }
}