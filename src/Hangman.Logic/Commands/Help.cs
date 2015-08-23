namespace Hangman.Logic.Commands
{
    internal class Help : ICommand
    {
        private Engine engine;

        internal Help(Engine gameEngine)
        {
            this.engine = gameEngine;
        }

        public void Execute()
        {
            this.engine.RevealLetter(this.engine.Word, this.engine.WordOfUnderscores);
            this.engine.IsHelpUsed = true;
        }
    }
}
