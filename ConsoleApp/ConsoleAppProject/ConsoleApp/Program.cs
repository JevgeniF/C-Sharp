using System;
using System.IO;
using System.Linq;
using GameEngine;
using GameUIConsole;
using MenuSystem;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main()
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
            menu.AddMenuItem(new MenuItem("Options", "O", menuOptions.RunMenu));

            menu.RunMenu();

            Console.WriteLine("");

            //App footer.
            Console.WriteLine("===> (c) 2020 <===");
        }

        private static string DefaultMenuAction() //Default action for not implemented menu functions
        {
            Console.WriteLine("Not implemented yet.");
            return "";
        }

        private static string Game() //Default action for game
        {
            var game = new Battleships();
            var boards = game.GetBoards();
            string userChoice;

            EndPoint:
            Console.WriteLine("Would you like to load previous game? (Y/N)");
            var option = Console.ReadLine()?.ToUpper().Trim();
            if (option == "Y")
            {
                LoadGameAction(game);
            }
            else if (option != "N" && option != "Y")
            {
                Console.WriteLine("No such Option");
                goto EndPoint;
            }

            do
            {
                if (Battleships.NextMoveByFirst)
                    Console.WriteLine("It's COMMANDER'S ONE turn");
                else if (!Battleships.NextMoveByFirst) Console.WriteLine("It's COMMANDER'S TWO turn");
                var menu = new Menu(MenuLevel.Game);
                menu.AddMenuItem(new MenuItem("Engage weapons systems", "P",
                    () =>
                    {
                        switch (Battleships.NextMoveByFirst)
                        {
                            case true:
                                ConsoleUi.DrawBoard(boards[0]);
                                break;
                            case false:
                                ConsoleUi.DrawBoard(boards[1]);
                                break;
                        }

                        GetMoveCoordinates();
                        Battleships.MakeAMove(Battleships.NextMoveByFirst ? boards[0] : boards[1]);

                        if (Battleships.NextMoveByFirst)
                            Console.WriteLine("It's COMMANDER'S ONE turn");
                        else if (!Battleships.NextMoveByFirst) Console.WriteLine("It's COMMANDER'S TWO turn");

                        return "";
                    }));
                // ReSharper disable once ConvertToLambdaExpression
                menu.AddMenuItem(new MenuItem("Save Game", "S", () => { return SaveGameAction(game); }));
                userChoice = menu.RunMenu();
            } while (userChoice != "E");

            return "";
        }

        private static void GetMoveCoordinates() // Get coordinates of user move
        {
            Console.WriteLine("Indicate a square for attack, Commander!");
            var userValue = Console.ReadLine()?.ToUpper().Trim() ?? "";
            Battleships.MoveCoordinates = userValue;
        }

        private static string SaveGameAction(Battleships game)
        {
            var defaultName = "save_" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
            Console.WriteLine($"File name ({defaultName}:");
            var fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName)) fileName = defaultName;

            var serializedGame = game.GetSerializedGameState();
            File.WriteAllText(fileName, serializedGame);
            return "";
        }

        private static void LoadGameAction(Battleships game)
        {
            var files = Directory.EnumerateFiles(".", "*.json").ToList();
            for (var i = 0; i < files.Count; i++) Console.WriteLine($"{i} - {files[i]}");
            Console.WriteLine("Enter SaveFile Number:");
            var number = Console.ReadLine();
            var fileNumber = files.Count + 1;
            var fileName = "";
            var success = number != null && int.TryParse(number.Trim(), out fileNumber);
            if (success)
                if (fileNumber >= 0 && files.Count > fileNumber)
                    fileName = files[fileNumber];

            var jsonString = File.ReadAllText(fileName);

            game.SetGameStateFromJson(jsonString);
        }

        private static string BoardSettings() //Default action for not implemented menu functions
        {
            Console.WriteLine("What size of board do you prefer? Enter width (max = 20):");

            var width = Convert.ToInt32(Console.ReadLine());
            if (width <= 20 && width > 0)
                Battleships.Width = width;
            else
                Console.WriteLine("Invalid width!");

            return "";
        }

        private static string
            ThemeReset() //Dedicated action for reversion of color theme back to default console colors.
        {
            Console.ResetColor();
            Console.WriteLine("Default Theme Set!");
            return "";
        }

        private static string ThemeChanger() // Action for Menu "Theme" items in Options/Graphics
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