namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;
    using Games;

    /// <summary>
    /// Help command class
    /// </summary>
    internal class Help : ICommand
    {
        /// <summary>
        /// Execute command. Reveals a hidden letter from the word
        /// </summary>
        /// <param name="gameEngine">The game engine</param>
        public void Execute(HangmanEngine gameEngine)
        {
            gameEngine.RevealLetter(gameEngine.HangmanGame.WordInitializer.Word, gameEngine.HangmanGame.WordInitializer.GuessedWordLetters);
            gameEngine.IsHelpUsed = true;
        }
    }
}
