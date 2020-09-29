using System;
using System.Collections.Generic;


namespace MenuSystem
{
    public enum MenuLevel
    {
        Root,
        First,
        Second
    }

    public class Menu
    {
        private Dictionary<string, MenuItem> MenuItems { get; } = new Dictionary<string, MenuItem>();
        private readonly MenuLevel _menuLevel;

        public Menu(MenuLevel level)
        {
            _menuLevel = level;
        }

        public void AddMenuItem(MenuItem item)
        {
            if (item.UserChoice == "")
            {
                throw new Exception($"UserChoice can't be empty");
            }

            MenuItems.Add(item.UserChoice, item);
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

                switch (_menuLevel)
                {
                    case MenuLevel.Root:
                        Console.WriteLine("   X) eXit");
                        break;
                    case MenuLevel.First:
                        Console.WriteLine("   M) Main Menu");
                        Console.WriteLine("   X) eXit");
                        break;
                    case MenuLevel.Second:
                        Console.WriteLine("   P) Previous Menu");
                        Console.WriteLine("   M) Main Menu");
                        Console.WriteLine("   X) eXit");
                        break;
                    default:
                        throw new Exception("Unknown menu depth!");
                }

                Console.Write("Your choice ->");

                // User choice formatting.
                userChoice = Console.ReadLine()?.ToUpper().Trim() ?? "";

                // User choice implementation.
                if (userChoice == "X")
                {
                    Console.WriteLine("Good bye!");
                    Environment.Exit(0);
                }

                if (userChoice == "P" & _menuLevel == MenuLevel.Second)
                {
                    break;
                }

                if (userChoice == "M")
                {

                }

                if (MenuItems.TryGetValue(userChoice, out var userMenuItem))
                {
                    userMenuItem.MethodToExecute();
                }
                else
                {
                    Console.WriteLine("I don't have such option!");
                }
            } while (userChoice != "X");
        }
    }
}