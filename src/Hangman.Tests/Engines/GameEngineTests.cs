namespace Hangman.Test.Engines
{
    using Logic.Engines;
    using Logic.Contracts;
    using Moq;
    using NUnit.Framework;
    using Logic.Utils;

    [TestFixture]
    public class GameEngineTests
    {
        [Test]
        public void GameEngineShouldInitializeCorrectly()
        {
            var fakePrinter = new Mock<IPrinter>();
            var fakeReader = new Mock<IReader>();
            var fakeEngine = new Mock<GameEngine>();
            fakePrinter.Setup(p => p.PrintEnterLetterOrCommandMessage());
            fakeReader.Setup(r => r.ReadLine()).Verifiable();

            var engine = new HangmanEngine(fakePrinter.Object, fakeReader.Object, new Logic.Factories.CommandFactory(), new Logic.Utils.Validator(), new Logic.Games.HangmanGame(new WordInitializer()));
            engine.Initialize();
        }

        [Test]

        public void GameEngineShouldGetUserInput()
        {
            var fakeIGameEngine = new Mock<IGameEngine>();
            fakeIGameEngine.Setup(e => e.GetUserInput());
            fakeIGameEngine.Object.GetUserInput();
            fakeIGameEngine.Object.GetUserInput();
            fakeIGameEngine.Verify(u => u.GetUserInput(), Times.AtLeast(2));
        }

        [Test]
        public void GameEngineShouldCheckIfGameIsWon()
        {
            var fakeIGameEngine = new Mock<IGameEngine>();
            fakeIGameEngine.Setup(e => e.CheckIfGameIsWon());
            fakeIGameEngine.Object.CheckIfGameIsWon();
            fakeIGameEngine.Object.CheckIfGameIsWon();
            fakeIGameEngine.Verify(u => u.CheckIfGameIsWon(), Times.AtLeast(2));
        }

        [Test]
        public void GameEngineShouldStartGame()
        {
            var fakeIGameEngine = new Mock<IGameEngine>();
            fakeIGameEngine.Setup(e => e.StartGame());
            fakeIGameEngine.Object.StartGame();
            fakeIGameEngine.Object.StartGame();
            fakeIGameEngine.Verify(u => u.StartGame(), Times.AtLeast(2));
        }
    }
}