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
            engine.PrintWelcomeMessage();
            while (!engine.IsCurrentGameEnded)
            {
                engine.PrintDisplayableWord();
                string suggestedLetter = engine.GetUserInput();
                if (suggestedLetter != string.Empty)
                {
                    engine.ProcessUserGuess(suggestedLetter);
                }
                else
                {
                    engine.ProcessCommand();
                }

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