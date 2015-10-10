namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    internal class LetterGuess : ICommand
    {
        private readonly char inputLetter;

        internal LetterGuess(string inputCommand)
        {
            this.inputLetter = inputCommand[0];
        }

        public void Execute(HangmanEngine engine)
        {
            engine.ProcessUserGuess(this.inputLetter);
        }
    }
}
