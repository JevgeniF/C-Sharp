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
        public List<MenuItem> MenuItems { get; } = new List<MenuItem>();
        private readonly MenuLevel _menuLevel;

        public Menu(MenuLevel level)
        {
            _menuLevel = level;
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
                if (_menuLevel == MenuLevel.Second && userChoice == "P")
                {
                    break;
                }
                var userMenuItem = MenuItems.FirstOrDefault(t => t.UserChoice == userChoice);
                if (userMenuItem != null)
                {
                    userMenuItem.MethodToExecute();
                }
                else
                {
                    Console.WriteLine("I don't have such option!");  
                }
            }
            while (userChoice != "X");
        }
    }
}