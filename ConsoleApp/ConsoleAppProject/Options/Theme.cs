using System;
using System.Collections;
using System.Collections.Generic;

namespace Options
{
    public class Theme
    {
        private List<ThemeItem> ThemeItems { get; } = new List<ThemeItem>();

        private readonly string[] _reservedColors = new[]
        {
            "black", "darkblue", "darkgreen", "darkcyan", "darkred",
            "darkmagenta", "darkyellow", "gray", "darkgray", "blue", "green", "cyan", "red", "magenta", "yellow",
            "white"
        };

        public void AddThemeItem(ThemeItem item)
        {
            if (item.UserChoice == "")
            {
                throw new Exception("UserChoice can't be empty");
            }

            if (!((IList) _reservedColors).Contains(item.UserChoice.ToLower()))
            {
                throw new Exception("Color can't be implemented");
            }

            ThemeItems.Add(item);
        }
    }
}