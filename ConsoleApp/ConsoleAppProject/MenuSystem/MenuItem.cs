namespace MenuSystem
{
    public sealed class MenuItem
    {
        private string Label { get; }
        private string UserChoice { get; }

        public MenuItem(string label, string userChoice)
        {
            Label = label;
            UserChoice = userChoice;
        }

        public override string ToString()
        {
            return $"   {UserChoice}) {Label}";
        }
    }
}