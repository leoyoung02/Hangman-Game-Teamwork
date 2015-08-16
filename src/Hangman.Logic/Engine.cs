namespace Hangman.Logic
{
    using System;

    internal class Engine
    {
        private static readonly Scoreboard Scoreboard = new Scoreboard();

        internal static string SelectRandomWord()
        {
            Array words = Enum.GetValues(typeof(Words.Dictionary));
            Words.Dictionary randomWord = (Words.Dictionary)words.GetValue(new Random().Next(words.Length));
            return randomWord.ToString().ToLower();
        }

        internal static char[] GenerateEmptyWordOfUnderscores(int wordLength)
        {
            char[] wordOfUnderscores = new char[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                wordOfUnderscores[i] = '_';
            }

            return wordOfUnderscores;
        }

        internal static bool CheckIfGameIsWon(char[] displayableWord, bool isHelpUsed, int numberOfMistakesMade)
        {
            bool wordIsRevealed = CheckIfWordIsRevealed(displayableWord);
            if (wordIsRevealed)
            {
                if (isHelpUsed)
                {
                    Console.WriteLine(
                        "You won with {0} mistakes but you have cheated. " +
                        "You are not allowed to enter into the scoreboard.",
                        numberOfMistakesMade);
                    PrintDisplayableWord(displayableWord);
                }
                else
                {
                    Console.WriteLine("You won with {0} mistakes.", numberOfMistakesMade);
                    PrintDisplayableWord(displayableWord);
                    Scoreboard.TryToSignToScoreboard(numberOfMistakesMade);
                }
            }

            return wordIsRevealed;
        }

        internal static void ProcessCommand(
            string command,
            string secretWord,
            char[] displayableWord,
            out bool hasAllGamesEnded,
            out bool isCurrentGameEnded,
            out bool isHelpUsed)
        {
            isCurrentGameEnded = false;
            hasAllGamesEnded = false;
            isHelpUsed = false;
            switch (command)
            {
                case "top":
                    Scoreboard.PrintCurrentScoreboard();
                    break;
                case "restart":
                    isCurrentGameEnded = true;
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    isCurrentGameEnded = true;
                    hasAllGamesEnded = true;
                    break;
                case "help":
                    HelpByRevealingLetter(secretWord, displayableWord);
                    isHelpUsed = true;
                    break;
            }
        }

        internal static void ProcessUserGuess(string suggestedLetter, string secretWord, char[] displayableWord, ref int numberOfMistakesMade)
        {
            int numberOfRevealedLetters = CheckUserGuess(suggestedLetter, secretWord, displayableWord);
            if (numberOfRevealedLetters > 0)
            {
                bool wordIsRevealed = CheckIfWordIsRevealed(displayableWord);
                if (!wordIsRevealed)
                {
                    if (numberOfRevealedLetters == 1)
                    {
                        Console.WriteLine("Good job! You revealed {0} letter.", numberOfRevealedLetters);
                    }
                    else
                    {
                        Console.WriteLine("Good job! You revealed {0} letters.", numberOfRevealedLetters);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter[0]);
                numberOfMistakesMade++;
            }
        }

        internal static string GetUserInput(out string command)
        {
            string suggestedLetter = string.Empty;
            command = string.Empty;
            bool correctInputIsTaken = false;
            while (!correctInputIsTaken)
            {
                Console.Write("\nEnter your guess or command: ");
                string inputLine = Console.ReadLine();
                inputLine = inputLine.ToLower();

                if (inputLine.Length == 1)
                {
                    bool isLetter = char.IsLetter(inputLine, 0);
                    if (isLetter)
                    {
                        suggestedLetter = inputLine;
                        correctInputIsTaken = true;
                    }
                    else
                    {
                        PrintInvalidEntryMessage();
                    }
                }
                else if (inputLine.Length == 0)
                {
                    PrintInvalidEntryMessage();
                }
                else if ((inputLine == "top") || (inputLine == "restart") ||
                    (inputLine == "help") || (inputLine == "exit"))
                {
                    command = inputLine;
                    correctInputIsTaken = true;
                }
                else
                {
                    PrintInvalidEntryMessage();
                }
            }

            return suggestedLetter;
        }

        internal static void PrintDisplayableWord(char[] displayableWord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nThe secret word is: ");
            foreach (var letter in displayableWord)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", letter);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
        }

        internal static void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                "<< Welcome to “Hangman” game >>\n" +
                "<< Please try to guess the secret word >>\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
                "Commands:\n" +
                "HELP \t\t Reveals a letter.\n" +
                "TOP \t\t Displays high scores.\n" +
                "RESTART \t Starts a new game.\n" +
                "EXIT \t\t Quits the game.");
            Console.ResetColor();
        }

        private static void HelpByRevealingLetter(string secretWord, char[] displayableWord)
        {
            int nextUnrevealedLetterIndex = 0;
            for (int i = 0; i < displayableWord.Length; i++)
            {
                if (displayableWord[i] == '_')
                {
                    nextUnrevealedLetterIndex = i;
                    break;
                }
            }

            char letterToBeRevealed = secretWord[nextUnrevealedLetterIndex];
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (letterToBeRevealed == secretWord[i])
                {
                    displayableWord[i] = letterToBeRevealed;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter '{0}'.", letterToBeRevealed);
        }

        private static void PrintInvalidEntryMessage()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        private static bool CheckIfWordIsRevealed(char[] displayableWord)
        {
            bool wordIsRevealed = true;
            for (int i = 0; i < displayableWord.Length; i++)
            {
                if (displayableWord[i] == '_')
                {
                    wordIsRevealed = false;
                    break;
                }
            }

            return wordIsRevealed;
        }

        private static int CheckUserGuess(string suggestedLetter, string secretWord, char[] displayableWord)
        {
            int numberOfRevealedLetters = 0;
            bool letterIsAlreadyRevealed = CheckIfLetterIsAlreadyRevealed(suggestedLetter, displayableWord);
            if (!letterIsAlreadyRevealed)
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (suggestedLetter[0] == secretWord[i])
                    {
                        displayableWord[i] = suggestedLetter[0];
                        numberOfRevealedLetters++;
                    }
                }
            }

            return numberOfRevealedLetters;
        }

        private static bool CheckIfLetterIsAlreadyRevealed(string suggestedLetter, char[] displayableWord)
        {
            bool letterIsAlreadyRevealed = false;
            for (int i = 0; i < displayableWord.Length; i++)
            {
                if (displayableWord[i] == suggestedLetter[0])
                {
                    letterIsAlreadyRevealed = true;
                }
            }

            return letterIsAlreadyRevealed;
        }
    }
}