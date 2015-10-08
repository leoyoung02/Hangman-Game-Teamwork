namespace Hangman.Logic.Commands
{
    using Contracts;

    internal class Help : ICommand
    {
        private HangmanEngine engine;

        internal Help(HangmanEngine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.RevealLetter(this.engine.WordInitializer.Word, this.engine.WordInitializer.GuessedWordLetters);
            this.engine.IsHelpUsed = true;
        }
    }
}
