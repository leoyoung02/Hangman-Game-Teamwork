using NUnit.Framework;
using Hangman.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Logic.Tests
{
    [TestFixture()]
    public class Playe
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException]
        public void PlayerInvalidNameTest(string name)
        {
            var player = new Player(name, 7);
        }

        [Test]
        public void PlayerIsCreatedWithCorrectFirstName()
        {
            var player = new Player("Pesho", 0);
            string actual = player.PlayerName;
            string expected = "Pesho";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void PlayerIsCreatedWithCorrectScore()
        {
            var player = new Player("Gosho", 7);
            var actual = player.Score;
            uint expected = 7;
            Assert.AreEqual(actual, expected);
        }
    }
}