using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        static ConsoleApp app = new ConsoleApp();

        static void init()
        {
            app.menuOptionColor = ConsoleColor.Green;
            app.SetMenuOption("F", "Submit words by file");
            app.SetMenuOption("M", "Submit words manually");
        }

        static void exit()
        {
            System.Environment.Exit(1);
        }

        static void doMenuOption(string option)
        {
            switch (option.ToUpper())
            {
                case "F":
                    break;
                case "M":
                    ManualWordUnscrambler();
                    break;
                default:
                    break;
            }
        }

        static void ManualWordUnscrambler()
        {
            
        }

        static void RunWordUnscrambler()
        {
            app.PrintMenu();
            string input = app.AskMenuOption();

            doMenuOption(input);

            Console.WriteLine();
            if (app.AskContinue()) RunWordUnscrambler();
            
        }
        static void Main(string[] args)
        {
            init();
            RunWordUnscrambler();
        }
    }
}
