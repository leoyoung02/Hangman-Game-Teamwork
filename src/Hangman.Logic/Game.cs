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
            while (!engine.IsCurrentGameEnded)
            {
                engine.Printer.PrintDisplayableWord(engine.WordOfUnderscores);
                engine.GetUserInput();

                bool isGameWon = engine.CheckIfGameIsWon();
                if (isGameWon)
                {
                    engine.IsCurrentGameEnded = true;
                }
            }

            return engine.HasAllGamesEnded;
        }
    }
}