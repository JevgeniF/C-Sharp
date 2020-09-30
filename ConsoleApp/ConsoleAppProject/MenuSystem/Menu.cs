using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuSystem
{
    public enum MenuLevel // Names for indicators of level depths.
    {
        Root,
        First,
        Secondary // for every level after First
    }

    public class Menu
    {
        private Dictionary<string, MenuItem> MenuItems { get; set; } =
            new Dictionary<string, MenuItem>(); // Dictionary for Menu Listings

        private readonly MenuLevel _menuLevel;
        private readonly string[] _reservedActions = new[] {"X", "M", "P"};

        public Menu(MenuLevel level)
        {
            _menuLevel = level;
        }

        public void AddMenuItem(MenuItem item) // Adding every menu item to Listing with User Choice check.
        {
            if (item.UserChoice == "")
            {
                throw new Exception("UserChoice can't be empty");
            }

            MenuItems.Add(item.UserChoice, item);
        }

        public string RunMenu() // main method for screening menus and functionality.
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
                        Console.WriteLine("   X) eXit"); // hardcoded main menu options
                        break;
                    case MenuLevel.First:
                        Console.WriteLine("   M) Main Menu"); // hardcoded first level menu options
                        Console.WriteLine("   X) eXit");
                        break;
                    case MenuLevel.Secondary:
                        Console.WriteLine("   P) Previous Menu"); // hardcoded every secondary level menu options
                        Console.WriteLine("   M) Main Menu");
                        Console.WriteLine("   X) eXit");
                        break;
                    default:
                        throw new Exception("Unknown menu depth!");
                }

                Console.Write("->");

                // User choice formatting.
                userChoice = Console.ReadLine()?.ToUpper().Trim() ?? "";

                // User interaction functions.
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

                if (_menuLevel == MenuLevel.Secondary && userChoice == "P")
                {
                    break;
                }
            } while (true);

            return userChoice;
        }
    }
}