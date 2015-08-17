using System;

namespace Hangman.Logic
{
    internal class ExitCommand : ICommand
    {
        private Engine engine;

        internal ExitCommand(Engine gameEngine)
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
