using System;

namespace MenuSystem
{
    public class Menu
    {
        private const string Title = "Main Menu";
        public void DrawMenu()
        {
            Console.WriteLine($"==== {Title} ====");
        }
    }
}