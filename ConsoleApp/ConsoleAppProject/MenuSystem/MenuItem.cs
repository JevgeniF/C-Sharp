using System;

namespace MenuSystem
{
    public class MenuItem
    {
        public virtual string Label { get; }
        public virtual string UserChoice { get; }
        public virtual Action MethodToExecute { get; }

        public MenuItem(string label, string userChoice, Action methodToExecute)
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