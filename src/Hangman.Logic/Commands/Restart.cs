namespace Hangman.Logic.Commands
{
    internal class Restart : ICommand
    {
        private Engine engine;

        internal Restart(Engine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.HasCurrentGameEnded = true;
        }
    }
}
