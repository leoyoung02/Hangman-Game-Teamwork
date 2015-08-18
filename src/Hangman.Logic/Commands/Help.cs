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
            this.engine.RevealeLetter(this.engine.Word, this.engine.DisplayableWord);
            this.engine.IsHelpUsed = true;
        }
    }
}
