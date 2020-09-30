using System;

namespace MenuSystem
{
    public sealed class MenuItem
    {
        private string Label { get; set; }
        public string UserChoice { get; set; }

        public static string? Background { get; set; }

        public static string? Foreground { get; set; }
        public Func<string> MethodToExecute { get; set; }

        public MenuItem(string label, string userChoice, Func<string> methodToExecute,
            string background = null!, string foreground = null!)
        {
            Label = label.Trim();
            UserChoice = userChoice.Trim();
            MethodToExecute = methodToExecute;
            if (background != null) Background = background.Trim().ToLower();
            if (foreground != null) Foreground = foreground.Trim().ToLower();
        }

        public override string ToString()
        {
            return $"   {UserChoice}) {Label}";
        }

    }
}