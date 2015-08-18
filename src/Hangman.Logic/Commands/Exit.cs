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
            engine.IsCurrentGameEnded = true;
            engine.HasAllGamesEnded = true;
        }
    }
}
