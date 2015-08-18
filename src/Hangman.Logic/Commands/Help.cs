namespace Hangman.Logic.Commands
{
    internal class Help : ICommand
    {
        private Engine engine;

        internal Help(Engine gameEngine)
        {
            engine = gameEngine;
        }
        public void Execute()
        {
            engine.RevealeLetter(engine.Word, engine.DisplayableWord);
            engine.IsHelpUsed = true;
        }
    }
}
