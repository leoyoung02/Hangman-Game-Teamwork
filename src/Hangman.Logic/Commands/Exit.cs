namespace Hangman.Logic.Commands
{
    using Contracts;

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
