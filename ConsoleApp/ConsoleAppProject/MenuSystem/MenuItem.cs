using System;

namespace MenuSystem
{
    public sealed class MenuItem
    {
        private string Label { get; }
        public string UserChoice { get; }
        public Func<string> MethodToExecute { get; }

        public MenuItem(string label, string userChoice, Func<string> methodToExecute)
        {
            Label = label.Trim();
            UserChoice = userChoice.Trim();
            MethodToExecute = methodToExecute;
        }

        public override string ToString()
        {
            return $"   {UserChoice}) {Label}";
        }
    }
}