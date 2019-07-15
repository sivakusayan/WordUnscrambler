﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class ConsoleApp
    {
        public ConsoleColor menuOptionColor { get; set; } = ConsoleColor.White;
        public int indent { get; set; } = 4;


        IDictionary<string, string> menuOptions = new Dictionary<string, string>();

        // --------------------------------------------------------------------- PRINTING UTILITY FUNCTIONS
        public void Write(string message)
        {
            string indentString = "";

            for (int i = 0; i < indent; i++) indentString += " ";
            Console.Write(indentString + message);
        }
        public void WriteLine(string message)
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
            menuOptions.Add(key.ToLower(), description);
        }

        // --------------------------------------------------------------------- MENU PRINTING
        public void PrintMenuOption(string key)
        {
            Console.ForegroundColor = menuOptionColor;
            Write(ToTitleCase(key));
            Console.ResetColor();
            Console.WriteLine($" - {menuOptions[key]}");
        }
        public void PrintMenu()
        {
            Console.WriteLine();
            foreach (string key in menuOptions.Keys) PrintMenuOption(key);
            Console.WriteLine();
        }

        // --------------------------------------------------------------------- MENU INPUT
        public string AskMenuOption()
        {
            Write("Enter a menu option: ");
            string option = Console.ReadLine();
            while (!menuOptions.ContainsKey(option.ToLower()))
            {
                Write("Please enter a valid option: ");
                option = Console.ReadLine();
            }
            return option;
        }

        public bool AskContinue()
        {
            Write("Would you like to continue? (Y/N): ");
            string option = Console.ReadLine();
            while (!option.ToUpper().Equals("Y") && !option.ToUpper().Equals("N"))
            {
                Write("Please enter a valid option: ");
                option = Console.ReadLine();
            }

            return option.ToUpper().Equals("Y");
        }
    }
}