namespace Hangman.Logic
{
    internal class RestartCommand : ICommand
    {
        private Engine engine;

        internal RestartCommand(Engine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            engine.IsCurrentGameEnded = true;
        }
    }
}
