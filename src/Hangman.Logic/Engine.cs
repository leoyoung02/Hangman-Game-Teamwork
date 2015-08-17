namespace Hangman.Logic
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    internal class Engine : WordInitializer
    {
        private static readonly Scoreboard scoreboard = new Scoreboard();

        private int mistakes;
        private bool hasAllGamesEnded;
        private bool isCurrentGameEnded;
        private bool isHelpUsed;

        internal Engine()
        {
            this.Mistakes = this.mistakes;
            this.HasAllGamesEnded = this.hasAllGamesEnded;
            this.IsCurrentGameEnded = this.isCurrentGameEnded;
            this.IsHelpUsed = this.isHelpUsed;
        }

        [DefaultValue(false)]
        internal bool HasAllGamesEnded
        {
            get { return this.hasAllGamesEnded; }
            private set { this.hasAllGamesEnded = value; }
        }

        [DefaultValue(false)]
        internal bool IsCurrentGameEnded
        {
            get { return this.isCurrentGameEnded; }
            set { this.isCurrentGameEnded = value; }
        }

        [DefaultValue(0)]
        private int Mistakes
        {
            get { return this.mistakes; }
            set { this.mistakes = value; }
        }

        [DefaultValue(false)]
        private bool IsHelpUsed
        {
            get { return this.isHelpUsed; }
            set { this.isHelpUsed = value; }
        }

        private string Command { get; set; }

        internal void PrintWelcomeMessage()
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

        internal bool CheckIfGameIsWon()
        {
            bool isWordRevealed = this.CheckIfWordIsRevealed(this.DisplayableWord);
            if (isWordRevealed)
            {
                if (this.IsHelpUsed)
                {
                    Console.WriteLine(
                        "You won with {0} mistakes but you have cheated. " +
                        "You are not allowed to enter into the scoreboard.",
                        this.Mistakes);
                    this.PrintDisplayableWord();
                }
                else
                {
                    Console.WriteLine("You won with {0} mistakes.", this.Mistakes);
                    this.PrintDisplayableWord();
                    scoreboard.TryToSign(this.Mistakes);
                }
            }

            return isWordRevealed;
        }

        internal void ProcessCommand()
        {
            switch (this.Command)
            {
                case "top":
                    scoreboard.PrintAllRecords();
                    break;
                case "restart":
                    this.IsCurrentGameEnded = true;
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    this.IsCurrentGameEnded = true;
                    this.HasAllGamesEnded = true;
                    break;
                case "help":
                    this.RevealeLetter(this.Word, this.DisplayableWord);
                    this.IsHelpUsed = true;
                    break;
            }
        }

        internal void ProcessUserGuess(string suggestedLetter)
        {
            int numberOfRevealedLetters = this.CheckUserGuess(suggestedLetter, this.Word, this.DisplayableWord);
            if (numberOfRevealedLetters > 0)
            {
                bool isWordRevealed = this.CheckIfWordIsRevealed(this.DisplayableWord);
                if (!isWordRevealed)
                {
                    Console.WriteLine(
                        numberOfRevealedLetters == 1
                            ? "Good job! You revealed {0} letter."
                            : "Good job! You revealed {0} letters.", 
                            numberOfRevealedLetters);
                }
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter[0]);
                this.Mistakes++;
            }
        }

        internal string GetUserInput()
        {
            string suggestedLetter = string.Empty;
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.Write("\nEnter your guess or command: ");
                string inputLine = Console.ReadLine();
                inputLine = inputLine.ToLower();

                if (inputLine.Length == 1)
                {
                    if (char.IsLetter(inputLine, 0))
                    {
                        suggestedLetter = inputLine;
                        isInputValid = true;
                    }
                    else
                    {
                        this.PrintInvalidEntryMessage();
                    }
                }
                else if (inputLine.Length == 0)
                {
                    this.PrintInvalidEntryMessage();
                }
                else if ((inputLine == "help") || (inputLine == "top") ||
                    (inputLine == "restart") || (inputLine == "exit"))
                {
                    this.Command = inputLine;
                    isInputValid = true;
                }
                else
                {
                    this.PrintInvalidEntryMessage();
                }
            }

            return suggestedLetter;
        }

        internal void PrintDisplayableWord()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nThe secret word is: ");
            foreach (var letter in this.DisplayableWord)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", letter);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
        }

        private void RevealeLetter(string secretWord, char[] displayableWord)
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

            Console.WriteLine("OK, let's reveal for you the next letter '{0}'.", letterToBeRevealed);
        }

        private void PrintInvalidEntryMessage()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        private bool CheckIfWordIsRevealed(char[] displayableWord)
        {
            return displayableWord.All(ch => ch != '_');
        }

        private int CheckUserGuess(string suggestedLetter, string secretWord, char[] displayableWord)
        {
            int numberOfRevealedLetters = 0;
            bool isLetterAlreadyRevealed = this.CheckIfLetterIsAlreadyRevealed(suggestedLetter, displayableWord);
            if (!isLetterAlreadyRevealed)
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

        private bool CheckIfLetterIsAlreadyRevealed(string suggestedLetter, char[] displayableWord)
        {
            bool isLetterRevealed = false;
            foreach (char letter in displayableWord)
            {
                if (letter == suggestedLetter[0])
                {
                    isLetterRevealed = true;
                }
            }

            return isLetterRevealed;
        }
    }
}