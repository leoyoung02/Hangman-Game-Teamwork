namespace Hangman.Logic
{
    internal class NewGame
    {
        internal static bool Play()
        {
            Engine.PrintWelcomeMessage();

            string word = Engine.SelectRandomWord();
            char[] displayableWord = Engine.GenerateEmptyWordOfUnderscores(word.Length);
            int numberOfMistakesMade = 0;

            bool hasAllGamesEnded = false;
            bool isCurrentGameEnded = false;
            bool isHelpUsed = false;

            while (!isCurrentGameEnded)
            {
                Engine.PrintDisplayableWord(displayableWord);
                string command = string.Empty;
                string suggestedLetter = Engine.GetUserInput(out command);
                if (suggestedLetter != string.Empty)
                {
                    Engine.ProcessUserGuess(suggestedLetter, word, displayableWord, ref numberOfMistakesMade);
                }
                else
                {
                    Engine.ProcessCommand(command, word, displayableWord, out hasAllGamesEnded, out isCurrentGameEnded, out isHelpUsed);
                }

                bool isGameWon = Engine.CheckIfGameIsWon(displayableWord, isHelpUsed, numberOfMistakesMade);

                if (isGameWon)
                {
                    isCurrentGameEnded = true;
                }
            }

            return hasAllGamesEnded;
        }
    }
}