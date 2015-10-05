namespace Hangman.Logic.Commands
{
    internal class Help : ICommand
    {
        private HangmanEngine engine;

        internal Help(HangmanEngine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.RevealLetter(this.engine.Word, this.engine.GuessedWordLetters);
            this.engine.IsHelpUsed = true;
        }
    }
}
