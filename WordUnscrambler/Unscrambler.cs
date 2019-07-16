using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    public class Unscrambler
    {
        public string[] unscrambledWordList { get; set; }

        private bool IsPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            IDictionary<char, int> characterCount = new Dictionary<char, int>();

            // Establish character counts for first string
            foreach (char character in str1.ToCharArray())
            {
                if (!characterCount.ContainsKey(character)) characterCount[character] = 0;
                characterCount[character] += 1;
            }

            // Subtract off character counts for second string
            foreach (char character in str2.ToCharArray())
            {
                if (!characterCount.ContainsKey(character)) return false;
                characterCount[character] -= 1;
            }

            // If all values are 0, the words have exact same character counts, and are permutations
            if (characterCount.Values.All(val => val == 0)) return true;
            return false;
        }

        public string[] GetMatches(string str)
        {
            List<string> matchList = new List<string>();

            foreach (string word in unscrambledWordList)
            {
                if (IsPermutation(word.ToLower(), str.ToLower())) matchList.Add(word);
            }
            return matchList.ToArray<string>();
        }
    }
}
