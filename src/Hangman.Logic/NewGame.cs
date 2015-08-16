namespace Hangman.Logic
{
    internal class NewGame
    {
        internal static bool Play()
        {
            Hangman.PrintWelcomeMessage();

            string w = Hangman.SelectRandomWord();
            char[] displayableWord = Hangman.GenerateEmptyWordOfUnderscores(w.Length);
            int numberOfMistakesMade = 0;

            bool flag = false;
            bool ff = false;
            bool ff2 = false;

            while (!ff)
            {
                Hangman.PrintDisplayableWord(displayableWord);
                string command = string.Empty;
                string suggestedLetter = Hangman.GetUserInput(out command);
                if (suggestedLetter != string.Empty)
                {
                    Hangman.ProcessUserGuess(suggestedLetter, w, displayableWord, ref numberOfMistakesMade);
                }
                else
                {
                    Hangman.ProcessCommand(command, w, displayableWord, out flag, out ff, out ff2);
                }

                bool gameIsWon = Hangman.CheckIfGameIsWon(displayableWord, ff2, numberOfMistakesMade);

                if (gameIsWon)
                {
                    ff = true;
                }
            }

            return flag;
        }
    }
}