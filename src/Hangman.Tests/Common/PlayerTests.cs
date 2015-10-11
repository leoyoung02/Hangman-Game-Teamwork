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
    }
}