using Hangman.Logic.Contracts;

namespace Hangman.Logic
{
    internal class Game : IPlayable
    {
        private IEngine engine;

        internal Game(IEngine engine) 
        {
            this.engine = engine;
        }

        public bool Play()
        {
            //Engine engine = new Engine();

            this.engine.Printer.PrintWelcomeMessage();
            while (!this.engine.HasCurrentGameEnded)
            {
                this.engine.Printer.PrintWordToGuess(this.engine.WordOfUnderscores);
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