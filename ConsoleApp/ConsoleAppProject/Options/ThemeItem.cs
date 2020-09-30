using System;

namespace Options
{
    public class ThemeItem
    {
        private string Label { get; }
        public string UserChoice { get; }
        private string Background { get; }
        private string Foreground { get; }
        public Func<string> MethodToExecute { get; }

        public ThemeItem(string label, string userChoice, Func<string> methodToExecute,
            string background = null, string foreground = null)
        {
            Label = label.Trim();
            UserChoice = userChoice.Trim();
            Background = background?.Trim();
            Foreground = foreground?.Trim();
            MethodToExecute = methodToExecute;
        }
        public override string ToString()
        {
            return $"   {UserChoice}) {Label}";
        }
    }
}