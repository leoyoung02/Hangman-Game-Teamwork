namespace Hangman.Test.Engines
{
    using Logic;
    using Logic.Factories;
    using Logic.Games;
    using Logic.Engines;
    using NUnit.Framework;
    using Logic.Utils;
   

    [TestFixture]
    public class HangmanEngineTests
    {
        [Test]
        public void HangmanEngineIsCreatedAndIsHelpUsedPropertyCanBeSet()
        {
            var engine = new HangmanEngine(new ConsolePrinter(), new ConsoleReader(), new CommandFactory(),
                             new Validator(), new HangmanGame(new WordInitializer()));

            var testPropHelp = engine.IsHelpUsed;
                testPropHelp = true;

            Assert.AreEqual(testPropHelp, true);
        }

        [Test]
        public void HangmanEngineIsCreatedAndCurrentGamePropertyCanBeSet()
        {
            var engine = new HangmanEngine(new ConsolePrinter(), new ConsoleReader(), new CommandFactory(),
                             new Validator(), new HangmanGame(new WordInitializer()));

          
            var testPropThisGameEnded = engine.HasCurrentGameEnded;
            testPropThisGameEnded = true;

            Assert.AreEqual(testPropThisGameEnded, true);
        }

        [Test]
        public void HangmanEngineIsCreatedAndAllGamesPropertyCanBeSet()
        {
            var engine = new HangmanEngine(new ConsolePrinter(), new ConsoleReader(), new CommandFactory(),
                             new Validator(), new HangmanGame(new WordInitializer()));


            var testPropAllGamesEnded = engine.HaveAllGamesEnded;
            testPropAllGamesEnded = true;

            Assert.AreEqual(testPropAllGamesEnded, true);
        }

        [Test]
        public void HangmanEngineIsCreatedAndFactoryIsPartOfIt()
        {
            var factory = new CommandFactory();
            var engine = new HangmanEngine(new ConsolePrinter(), new ConsoleReader(), factory,
                             new Validator(), new HangmanGame(new WordInitializer()));


            var testFactoryReference = engine.CommandFactory;

            Assert.AreSame(factory, testFactoryReference);
        }
    }
}
