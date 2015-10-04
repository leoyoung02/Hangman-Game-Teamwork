using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
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
