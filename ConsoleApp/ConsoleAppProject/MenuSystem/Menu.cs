using System;
using System.Collections.Generic;

namespace MenuSystem
{
    public class Menu
    {
        private List<MenuItem> MenuItems { get; }

        public Menu()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem("New Game: Player vs Player", "1"),
                new MenuItem("New Game: Player vs AI", "2"),
                new MenuItem("New Game: AI vs AI", "3")
            };
        }

        public void RunMenu()
        {
            string userChoice;

            do
            {
                foreach (var menuItem in MenuItems)
                {
                    Console.WriteLine(menuItem);
                }
                Console.WriteLine("   L) Load Saved Game");
                Console.WriteLine("   O) Options");
                Console.WriteLine("   X) eXit");

                Console.Write("Your choice ->");

                // User choice formatting.
                userChoice = Console.ReadLine()?.ToUpper().Trim() ?? "";

                // User choice implementation.
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Not implemented yet.");
                        break;
                    case "2":
                        Console.WriteLine("Not implemented yet.");
                        break;
                    case "3":
                        Console.WriteLine("Not implemented yet.");
                        break;
                    case "L":
                        Console.WriteLine("Not implemented yet.");
                        break;
                    case "O":
                        Console.WriteLine("Not implemented yet.");
                        break;
                    case "X":
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine("I don't have such option!");
                        break;
                }
            } while (userChoice != "X");
        }
    }
}