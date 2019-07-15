using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordUnscrambler.Test.Unit
{
    [TestClass]
    public class UnscramblerTest
    {
        private readonly PrivateObject _unscrambler = new PrivateObject(new Unscrambler());

        [TestMethod]
        public void ReturnsTrueIfWordsArePermutations()
        {
            string str1 = "apple";
            string str2 = "alepp";
            Object result = _unscrambler.Invoke("IsPermutation", new[] { str1, str2 });

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void ReturnsFalseIfWordsArentPermutations()
        {
            string str1 = "apple";
            string str2 = "aleppb";
            Object result = _unscrambler.Invoke("IsPermutation", new[] { str1, str2 });

            Assert.AreEqual(result, false);
        }
    }
}
