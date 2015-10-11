namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    /// <summary>
    /// Guess letter command class
    /// </summary>
    internal class LetterGuess : ICommand
    {
        private readonly char inputLetter;

        /// <summary>
        /// Command constructor
        /// </summary>
        /// <param name="inputCommand">The command string</param>
        // TODO: should only axxept letters
        internal LetterGuess(string inputCommand)
        {
            this.inputLetter = inputCommand[0];
        }

        /// <summary>
        /// Ececute command. Calls a method to process the letter guess
        /// </summary>
        /// <param name="engine"></param>
        public void Execute(HangmanEngine engine)
        {
            engine.ProcessUserGuess(this.inputLetter);
        }
    }
}
