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

        private ConsolePrinter printer;

        internal Engine()
        {
            this.Mistakes = this.mistakes;
            this.HasAllGamesEnded = this.hasAllGamesEnded;
            this.IsCurrentGameEnded = this.isCurrentGameEnded;
            this.IsHelpUsed = this.isHelpUsed;
            this.scoreboard = Scoreboard.Instance;
            this.printer = new ConsolePrinter();
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

        internal bool CheckIfGameIsWon()
        {
            bool isWordRevealed = this.CheckIfWordIsRevealed(this.DisplayableWord);
            if (isWordRevealed)
            {
                this.printer.PrintWinMessage(this.Mistakes, this.isHelpUsed, this.scoreboard);
                this.printer.PrintDisplayableWord(this.DisplayableWord);
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
                    this.printer.PrintNumberOfRevealedLetters(numberOfRevealedLetters);
                }
            }
            else
            {
                this.printer.PrintNoRevealedLettersMessage(suggestedLetter);
                this.Mistakes++;
            }
        }

        internal void GetUserInput()
        {
            bool isInputValid = false;
            ICommand command;
            while (!isInputValid)
            {
                this.printer.PrintEnterLetterOrCommandMessage();
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
                            this.printer.PrintInvalidEntryMessage();
                            isInputValid = false;
                            continue;
                    }
                }

                command.Execute();
            }
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

            this.printer.PrintRevealLetterMessage(letterToBeRevealed);
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