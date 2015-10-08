namespace Hangman.Logic.Commands
{
    using Contracts;
    internal class Restart : ICommand
    {
        private HangmanEngine engine;

        internal Restart(HangmanEngine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.HasCurrentGameEnded = true;
        }
    }
}
