using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class ConsoleMenu
    {
        public ConsoleColor menuOptionColor { get; set; } = ConsoleColor.White;
        public int indent { get; set; } = 4;


        IDictionary<string, string> options = new Dictionary<string, string>();

        // --------------------------------------------------------------------- PRINTING UTILITY FUNCTIONS
        private void print(string message)
        {
            string indentString = "";

            for (int i = 0; i < indent; i++) indentString += " ";
            Console.Write(indentString + message);
        }
        private void printLine(string message)
        {
            string indentString = "";

            for (int i = 0; i < indent; i++) indentString += " ";
            Console.WriteLine(indentString + message);
        }
        private string ToTitleCase(string str)
        {
            return new CultureInfo("en").TextInfo.ToTitleCase(str.ToLower());
        }

        // --------------------------------------------------------------------- MENU MANIPULATION
        public void SetMenuOption(string key, string description)
        {
            options.Add(key.ToLower(), description);
        }

        // --------------------------------------------------------------------- MENU PRINTING
        public void PrintMenuOption(string key)
        {
            Console.ForegroundColor = menuOptionColor;
            print(ToTitleCase(key));
            Console.ResetColor();
            Console.WriteLine($" - {options[key]}");
        }
        public void PrintMenu()
        {
            Console.WriteLine();
            foreach (string key in options.Keys) PrintMenuOption(key);
            Console.WriteLine();
        }

        // --------------------------------------------------------------------- MENU INPUT
        public string AskMenuOption()
        {
            print("Enter a menu option: ");
            string option = Console.ReadLine();
            while (!options.ContainsKey(option.ToLower()))
            {
                print("Please enter a valid option: ");
                option = Console.ReadLine();
            }
            return option;
        }
    }
}
