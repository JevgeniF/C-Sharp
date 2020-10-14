using System;
using System.Runtime.Serialization.Formatters;
using GameEngine;
using GameUIConsole;
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
            menuGraphics.AddMenuItem(new MenuItem("Old Radar", "2", ThemeChanger, "black", "green"));

            var menuOptions = new Menu(MenuLevel.First);
            menuOptions.AddMenuItem(new MenuItem("Color", "1", menuGraphics.RunMenu));
            menuOptions.AddMenuItem(new MenuItem("Board Size", "2", BoardSettings));

            var menu = new Menu(MenuLevel.Root);
            menu.AddMenuItem(new MenuItem("New Game: Player vs Player", "1", Game));
            menu.AddMenuItem(new MenuItem("New Game: Player vs AI", "2", DefaultMenuAction));
            menu.AddMenuItem(new MenuItem("New Game: AI vs AI", "3", DefaultMenuAction));
            menu.AddMenuItem(new MenuItem("Options", "4", menuOptions.RunMenu));

            menu.RunMenu();

            Console.WriteLine("");

            //App footer.
            Console.WriteLine("===> (c) 2020 <===");
        }

        static string DefaultMenuAction() //Default action for not implemented menu functions
        {
            Console.WriteLine("Not implemented yet.");
            return "";
        }

        static string Game() //Default action for game
        {
            var game = new Battleships();
            var boards = game.GetBoards();
            string userChoice;

            do
            {   var menu = new Menu(MenuLevel.Game);
                menu.AddMenuItem(new MenuItem($"Player {(game.NextMoveByFirst ? "One" : "Two")} make a move", "P",
                    () =>
                    {
                        switch (game.NextMoveByFirst)
                        {
                            case true: ;
                                ConsoleUi.DrawBoard((CellState[,]) boards[0]);
                                break;
                            case false:
                                ConsoleUi.DrawBoard((CellState[,]) boards[1]);
                                break;
                        }
                        
                        GetMoveCoordinates();
                        if (game.NextMoveByFirst)
                        {
                            game.MakeAMove((CellState[,]) boards[0]);
                        }
                        else
                        {
                            game.MakeAMove((CellState[,]) boards[1]);
                        }

                        Console.Clear();
                        return "";
                    }));
                menu.AddMenuItem(new MenuItem("Save Game", "S", DefaultMenuAction));
                userChoice = menu.RunMenu();
            } while (userChoice != "E");

            return "";
        }

        static string GetMoveCoordinates() // Get coordinates of user move
        {
            Console.WriteLine("Indicate a square for attack, Commander!");
            var userValue = Console.ReadLine();
            Battleships.MoveCoordinates = userValue;
            return userValue;
        }

        static string BoardSettings() //Default action for not implemented menu functions
        {
            Console.WriteLine("What size of board do you prefer? Enter width (max = 20):");
            int width = Convert.ToInt32(Console.ReadLine());

            if (width <= 20 && width > 0)
            {
                Battleships.Width = width;
            }
            else
            {
                Console.WriteLine("Invalid width!");
            }

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