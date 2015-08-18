namespace Hangman.Logic.Commands
{
    internal class LetterGuess : ICommand
    {
        private readonly char inputLetter;
        private Engine engine;

        internal LetterGuess(string inputCommand, Engine gameEngine)
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
