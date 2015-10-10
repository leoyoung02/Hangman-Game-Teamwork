namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;
    using Games;

    internal class Help : ICommand
    {
        public void Execute(HangmanEngine gameEngine)
        {
            gameEngine.RevealLetter(gameEngine.HangmanGame.WordInitializer.Word, gameEngine.HangmanGame.WordInitializer.GuessedWordLetters);
            gameEngine.IsHelpUsed = true;
        }
    }
}
