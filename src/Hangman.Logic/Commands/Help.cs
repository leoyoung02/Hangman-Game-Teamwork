namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;
    using Games;

    internal class Help : ICommand
    {
        private HangmanGame game;
        private HangmanEngine gameEngine;
        internal Help(HangmanEngine gameEngine, HangmanGame game)
        {
            this.GameEngine = gameEngine;
            this.game = game;
        }

        public HangmanEngine GameEngine
        {
            get
            {
                return this.gameEngine;
            }

            private set
            {
                this.gameEngine = value;
            }
        }

        public void Execute()
        {
            this.GameEngine.RevealLetter(this.game.WordInitializer.Word, this.game.WordInitializer.GuessedWordLetters);
            this.GameEngine.IsHelpUsed = true;
        }
    }
}
