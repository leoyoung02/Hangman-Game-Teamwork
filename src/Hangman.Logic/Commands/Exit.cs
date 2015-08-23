namespace Hangman.Logic.Commands
{
    internal class Exit : ICommand
    {
        private Engine engine;

        internal Exit(Engine gameEngine)
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
