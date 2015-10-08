namespace Hangman.Logic
{
    using Contracts;

    internal class Game : IPlayable
    {
        private IEngine engine;

        internal Game(IEngine engine) 
        {
            this.engine = engine;
        }

        public bool Play()
        {
            this.engine.Printer.PrintWelcomeMessage();
            while (!this.engine.HasCurrentGameEnded)
            {
                this.engine.Printer.PrintWordToGuess(this.engine.WordInitializer.GuessedWordLetters);
                this.engine.GetUserInput();

                bool isGameWon = this.engine.CheckIfGameIsWon();
                if (isGameWon)
                {
                    this.engine.HasCurrentGameEnded = true;
                }
            }

            return this.engine.HaveAllGamesEnded;
        }
    }
}