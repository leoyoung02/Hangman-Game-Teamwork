namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;
    using Games;

    internal class Help : ICommand
    {
        protected HangmanEngine engine;
        private HangmanGame game;

        internal Help(HangmanEngine gameEngine, HangmanGame game)
        {
            this.engine = gameEngine;
            this.game = game;
        }

        public void Execute()
        {
            this.engine.RevealLetter(this.game.WordInitializer.Word, this.game.WordInitializer.GuessedWordLetters);
            this.engine.IsHelpUsed = true;
        }
    }
}
