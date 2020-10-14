using System;

namespace MenuSystem
{
    public sealed class MenuItem
    {
        //Menu Item Constructor
        public MenuItem(string label, string userChoice, Func<string> methodToExecute,
            string background = null!, string foreground = null!)
        {
            Label = label.Trim();
            UserChoice = userChoice.Trim();
            MethodToExecute = methodToExecute;
            if (background != null) Background = background.Trim().ToLower();
            if (foreground != null) Foreground = foreground.Trim().ToLower();
        }

        private string Label { get; }
        public string UserChoice { get; }
        public static string? Background { get; private set; } // For Theme Menu Item only. Null by default
        public static string? Foreground { get; private set; } // For Theme Menu Item only. Null by default
        public Func<string> MethodToExecute { get; }

        public override string ToString()
        {
            return $"   {UserChoice}) {Label}";
        }
    }
}