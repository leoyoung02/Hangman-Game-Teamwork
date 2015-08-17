namespace Hangman.Logic
{
    internal class GuessLetterCommand : ICommand
    {
        private char inputLetter;
        private Engine engine;

        internal GuessLetterCommand(string inputCommand, Engine gameEngine)
        {
            this.inputLetter = inputCommand[0];
            this.engine = gameEngine;
        }

        public void Execute()
        {
            engine.ProcessUserGuess(inputLetter);
        }
    }
}
