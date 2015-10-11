namespace Hangman.Test.Games
{
    using Logic.Games;
    using Logic.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HangmanGameTest
    {
        [TestMethod]

        public void HangmanGameIsCreatedAtLeastTwice()
        {
            var wordInitializer = new WordInitializer();

            var gameOne = new HangmanGame(wordInitializer);
            var gameTwo = new HangmanGame(wordInitializer);

            Assert.ReferenceEquals(gameOne.WordInitializer, gameTwo.WordInitializer);
        }
    }
}
