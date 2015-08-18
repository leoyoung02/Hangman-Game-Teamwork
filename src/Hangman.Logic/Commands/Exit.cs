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
            this.engine.IsCurrentGameEnded = true;
            this.engine.HasAllGamesEnded = true;
        }
    }
}
