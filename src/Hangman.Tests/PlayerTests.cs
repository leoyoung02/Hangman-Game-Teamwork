namespace Hangman.Tests
{
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {

        [TestMethod]

        public void PlayerIsCreatedWithCorrectFirstName()
        {
            var player = new Player("Pesho", 0);
            var actual = player.PlayerName;
            var expected = "Pesho";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PlayerIsCreatedWithCorrectScore()
        {
            var player = new Player("Gosho", 7);
            var actual = player.Score;
            var expected = 7;
            Assert.AreEqual(actual, expected);
        }
    }
}
