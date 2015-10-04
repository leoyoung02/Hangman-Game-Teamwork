using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    internal class Exit : ICommand
    {
        private HangmanEngine engine;

        internal Exit(HangmanEngine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.HasCurrentGameEnded = true;
            this.engine.HaveAllGamesEnded = true;
        }
    }
}
