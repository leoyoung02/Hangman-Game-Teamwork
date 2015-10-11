namespace Hangman.Tests
{
    using Logic.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WordInitializerTests
    {
        [TestMethod]
        public void WordIsCreatedRandomly()
        {
            var wordOne = new WordInitializer();
            var wordTwo = new WordInitializer();

            Assert.AreNotEqual(wordOne, wordTwo);
        }

        [TestMethod]
        public void WordInitializerGenerateWordOfUnderscoresEqualsWordLengthInUndersores()
        {
            // var word = new WordInitializer();
            // var result = word.Word;
        }
    }
}
