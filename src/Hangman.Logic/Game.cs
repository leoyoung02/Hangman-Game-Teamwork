namespace Hangman.Logic
{
    internal class Game
    {
        internal Game() 
        {
        }

        internal bool Play()
        {
            Engine engine = new Engine();

            engine.Printer.PrintWelcomeMessage();
            while (!engine.HasCurrentGameEnded)
            {
                engine.Printer.PrintWordToGuess(engine.WordOfUnderscores);
                engine.GetUserInput();

                bool isGameWon = engine.CheckIfGameIsWon();
                if (isGameWon)
                {
                    engine.HasCurrentGameEnded = true;
                }
            }

            return engine.HaveAllGamesEnded;
        }
    }
}