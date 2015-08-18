namespace Hangman.Logic
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Commands;

    internal class Engine : WordInitializer
    {
        private readonly Scoreboard scoreboard;

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
            this.scoreboard = Scoreboard.Instance;
        }

        [DefaultValue(false)]
        internal bool HasAllGamesEnded
        {
            get { return this.hasAllGamesEnded; }
            set { this.hasAllGamesEnded = value; }
        }

        [DefaultValue(false)]
        internal bool IsCurrentGameEnded
        {
            get { return this.isCurrentGameEnded; }
            set { this.isCurrentGameEnded = value; }
        }

        [DefaultValue(false)]
        internal bool IsHelpUsed
        {
            get { return this.isHelpUsed; }
            set { this.isHelpUsed = value; }
        }

        [DefaultValue(0)]
        private int Mistakes
        {
            get { return this.mistakes; }
            set { this.mistakes = value; }
        }

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
                    this.scoreboard.TryToSign(this.Mistakes);
                }
            }

            return isWordRevealed;
        }

        internal void ProcessUserGuess(char suggestedLetter)
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
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter);
                this.Mistakes++;
            }
        }

        internal void GetUserInput()
        {
            bool isInputValid = false;
            ICommand command;
            while (!isInputValid)
            {
                Console.Write("\nEnter your guess letter or command: ");
                string inputLine = Console.ReadLine();
                inputLine = inputLine.ToLower();

                if (inputLine.Length == 1 && char.IsLetter(inputLine[0]))
                {
                    command = new LetterGuess(inputLine, this);
                    isInputValid = true;
                }
                else
                {
                    isInputValid = true;
                    switch (inputLine)
                    {
                        case "help":
                            command = new Help(this);
                            break;
                        case "top":
                            command = new Top(this.scoreboard);
                            break;
                        case "restart":
                            command = new Restart(this);
                            break;
                        case "exit":
                            command = new Exit(this);
                            break;
                        default:
                            this.PrintInvalidEntryMessage();
                            isInputValid = false;
                            continue;
                    }
                }

                command.Execute();
            }
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

        internal void RevealeLetter(string secretWord, char[] displayableWord)
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

        internal void PrintInvalidEntryMessage()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        private bool CheckIfWordIsRevealed(char[] displayableWord)
        {
            return displayableWord.All(ch => ch != '_');
        }

        private int CheckUserGuess(char suggestedLetter, string secretWord, char[] displayableWord)
        {
            int numberOfRevealedLetters = 0;
            bool isLetterAlreadyRevealed = this.CheckIfLetterIsAlreadyRevealed(suggestedLetter, displayableWord);
            if (!isLetterAlreadyRevealed)
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (suggestedLetter == secretWord[i])
                    {
                        displayableWord[i] = suggestedLetter;
                        numberOfRevealedLetters++;
                    }
                }
            }

            return numberOfRevealedLetters;
        }

        private bool CheckIfLetterIsAlreadyRevealed(char suggestedLetter, char[] displayableWord)
        {
            bool isLetterRevealed = false;
            foreach (char letter in displayableWord)
            {
                if (letter == suggestedLetter)
                {
                    isLetterRevealed = true;
                }
            }

            return isLetterRevealed;
        }
    }
}