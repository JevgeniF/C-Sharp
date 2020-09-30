using System;
using System.Collections.Generic;
using System.Linq;

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
        private Dictionary<string, MenuItem> MenuItems { get; set; } = new Dictionary<string, MenuItem>();
        private readonly MenuLevel _menuLevel;
        private readonly string[] _reservedActions = new[] {"X", "M", "P"};

        public Menu(MenuLevel level)
        {
            _menuLevel = level;
        }

        public void AddMenuItem(MenuItem item)
        {
            if (item.UserChoice == "")
            {
                throw new Exception("UserChoice can't be empty");
            }

            MenuItems.Add(item.UserChoice, item);
        }

        public string RunMenu()
        {
            string userChoice;

            do
            {
                foreach (var menuItem in MenuItems)
                {
                    Console.WriteLine(menuItem.Value);
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

                if (!_reservedActions.Contains(userChoice))
                {
                    if (MenuItems.TryGetValue(userChoice, out var userMenuItem))
                    {
                        userChoice = userMenuItem.MethodToExecute();
                    }
                    else
                    {
                        Console.WriteLine("I don't have such option!");
                    }
                }

                if (userChoice == "X")
                {
                    if (_menuLevel == MenuLevel.Root)
                    {
                        Console.WriteLine("Good bye!");
                    }

                    break;
                }

                if (_menuLevel != MenuLevel.Root && userChoice == "M")
                {
                    break;
                }

                if (_menuLevel == MenuLevel.Second && userChoice == "P")
                {
                    break;
                }

            } while (true);

            return userChoice;
        }
    }
}