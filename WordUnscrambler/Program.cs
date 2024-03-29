using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        static ConsoleApp app = new ConsoleApp();
        static Unscrambler unscrambler = new Unscrambler();

        const string UnscrambledWordsFilePath = "words.txt";

        static void Init()
        {
            app.menuOptionColor = ConsoleColor.Green;
            app.SetMenuOption("F", "Submit words by file");
            app.SetMenuOption("M", "Submit words manually");
            try
            {
                unscrambler.unscrambledWordList = File.ReadAllLines(UnscrambledWordsFilePath);
            } catch
            {
                app.WriteLine("Sorry, we cannot initialize the unscrambled word list. (Did you check the file path?)");
                app.WriteLine("Shutting down...");
                Thread.Sleep(7000);
                Exit();
            }
        }

        static void Exit()
        {
            System.Environment.Exit(1);
        }

        static void DoMenuOption(string option)
        {
            switch (option.ToUpper())
            {
                case "F":
                    FileWordUnscrambler();
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
            app.NewPage();
            app.Write("Enter a comma separated list of words (Ex: apple,pear,orange): ");
            string[] wordList = app.Read().Split(',');

            UnscrambleList(wordList);
        }

        static void FileWordUnscrambler()
        {
            app.NewPage();
            app.Write("Enter a file path of scrambled words (Ex: scrambledWords.txt): ");
            try
            {
                string[] wordList = File.ReadAllLines(app.Read());
                UnscrambleList(wordList);
            } catch
            {
                app.WriteLine("Sorry, we cannot detect that file path.");
            }
        }

        static void UnscrambleList(string[] scrambledWords)
        {
            foreach (string word in scrambledWords)
            {
                app.WriteLine();
                app.WriteLine($"Finding matches for {word}...");
                string[] matchList = unscrambler.GetMatches(word);
                if (matchList.Length < 1) app.WriteLine("No matches found.");
                foreach (string match in matchList)
                {
                    app.WriteLine(match);
                }
            }
        }

        static void RunWordUnscrambler()
        {
            app.NewPage();
            app.PrintMenu();
            string input = app.AskMenuOption();

            DoMenuOption(input);

            Console.WriteLine();
            if (app.AskContinue()) RunWordUnscrambler();
            
        }
        static void Main(string[] args)
        {
            Init();
            RunWordUnscrambler();
        }
    }
}
