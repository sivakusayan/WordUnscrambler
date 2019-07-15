using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class ConsoleMenu
    {
        public ConsoleColor menuOptionColor { get; set; } = ConsoleColor.White;


        IDictionary<string, string> options = new Dictionary<string, string>();

        public void setMenuOption(string key, string description)
        {
            options.Add(key, description);
        }

        public void printMenuOption(string key)
        {
            Console.ForegroundColor = menuOptionColor;
            Console.WriteLine(key);
            Console.ResetColor();
            Console.Write($" - {options[key]}");
        }

        public void printMenu()
        {
            Console.WriteLine("--------------------------------------------------");
            foreach (string key in options.Keys) printMenuOption(key);
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
