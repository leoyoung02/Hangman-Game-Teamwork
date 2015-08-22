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
            ConsolePrinter consolePrinter = new ConsolePrinter();

            consolePrinter.PrintWelcomeMessage();
            while (!engine.IsCurrentGameEnded)
            {
                consolePrinter.PrintDisplayableWord(engine.DisplayableWord);
                engine.GetUserInput();

                bool isGameWon = engine.CheckIfGameIsWon(consolePrinter);
                if (isGameWon)
                {
                    engine.IsCurrentGameEnded = true;
                }
            }

            return engine.HasAllGamesEnded;
        }
    }
}