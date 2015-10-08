namespace Hangman.Logic.Commands
{
    using Contracts;

    internal class LetterGuess : ICommand
    {
        private readonly char inputLetter;
        private HangmanEngine engine;

        internal LetterGuess(string inputCommand, HangmanEngine gameEngine)
        {
            this.inputLetter = inputCommand[0];
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.ProcessUserGuess(this.inputLetter);
        }
    }
}
