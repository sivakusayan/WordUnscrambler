using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        static ConsoleMenu menu = new ConsoleMenu();

        static void init()
        {
            menu.menuOptionColor = ConsoleColor.Green;
            menu.SetMenuOption("F", "Submit words by file");
            menu.SetMenuOption("M", "Submit words manually");
        }

        static void exit()
        {
            System.Environment.Exit(1);
        }

        static void RunWordUnscrambler()
        {
            menu.PrintMenu();
            string input = menu.AskMenuOption();

            Console.WriteLine();
            if (menu.AskContinue()) RunWordUnscrambler();
            
        }
        static void Main(string[] args)
        {
            init();
            RunWordUnscrambler();
        }
    }
}
