using NUnit.Framework;
using Hangman.Logic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Factories.Tests
{
    [TestFixture()]
    public class CommandFactoryTests
    {
        [TestCase(null)]
        [TestCase("Lizzard")]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException]
        public void CreateCommandInvalidCommandTest(string commandString)
        {
            var factory = new CommandFactory();
            ICommand command=factory.CreateCommand(commandString);
        }
    }
}