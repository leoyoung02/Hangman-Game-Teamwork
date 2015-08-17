namespace Hangman.Logic
{
    internal class HelpCommand : ICommand
    {
        private Engine engine;

        internal HelpCommand(Engine gameEngine)
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
