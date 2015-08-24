namespace Hangman.Logic
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Commands;
    using Utils;

    internal class Engine : WordInitializer
    {
        private readonly Scoreboard scoreboard;

        private int mistakes;
        private bool haveAllGamesEnded;
        private bool hasCurrentGameEnded;
        private bool isHelpUsed;

        private ConsolePrinter printer;

        internal Engine()
        {
            this.Mistakes = this.mistakes;
            this.HaveAllGamesEnded = this.haveAllGamesEnded;
            this.HasCurrentGameEnded = this.hasCurrentGameEnded;
            this.IsHelpUsed = this.isHelpUsed;
            this.scoreboard = Scoreboard.Instance;
            this.printer = new ConsolePrinter();
        }

        internal bool HaveAllGamesEnded
        {
            get 
            {
                return this.haveAllGamesEnded;
            }

            set
            {
                this.haveAllGamesEnded = value; 
            }
        }

        internal bool HasCurrentGameEnded
        {
            get 
            { 
                return this.hasCurrentGameEnded;
            }

            set
            { 
                this.hasCurrentGameEnded = value; 
            }
        }

        internal bool IsHelpUsed
        {
            get 
            {
                return this.isHelpUsed; 
            }

            set
            {
                this.isHelpUsed = value;
            }
        }

        private int Mistakes
        {
            get 
            {
                return this.mistakes; 
            }

            set 
            {
                this.mistakes = value;
            }
        }

        internal ConsolePrinter Printer
        {
            get 
            {
                return this.printer; 
            }

            private set 
            {
                this.printer = value;
            }
        }

        internal bool CheckIfGameIsWon()
        {
            bool isWordRevealed = this.CheckIfWordIsRevealed(this.WordOfUnderscores);
            if (isWordRevealed)
            {
                this.printer.PrintWinMessage(this.Mistakes, this.isHelpUsed, this.scoreboard);
                string currentPlayerName = this.scoreboard.AskForPlayerName();
                this.scoreboard.AddNewRecord(currentPlayerName, this.Mistakes);
                this.scoreboard.PrintAllRecords();
                this.printer.PrintWordToGuess(this.WordOfUnderscores);
            }

            return isWordRevealed;
        }

        internal void ProcessUserGuess(char suggestedLetter)
        {
            int numberOfRevealedLetters = this.CheckUserGuess(suggestedLetter, this.Word, this.WordOfUnderscores);
            if (numberOfRevealedLetters > 0)
            {
                bool isWordRevealed = this.CheckIfWordIsRevealed(this.WordOfUnderscores);
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
            var validator = new Validator();
            bool isInputValid = false;
            ICommand command;
            while (!isInputValid)
            {
                this.printer.PrintEnterLetterOrCommandMessage();
                string inputCommand = Console.ReadLine();
                inputCommand = inputCommand.ToLower();

                if(validator.InputCommantValidator(inputCommand))
                {
                    isInputValid = true;
                    switch (inputCommand)
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
                            command = new LetterGuess(inputCommand, this);
                            break;
                    }
                    command.Execute();
                }
            }
        }

        internal void RevealLetter(string secretWord, char[] wordToGuess)
        {
            int nextUnrevealedLetterIndex = 0;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == '_')
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
                    wordToGuess[i] = letterToBeRevealed;
                }
            }

            this.printer.PrintRevealLetterMessage(letterToBeRevealed);
        }

        private bool CheckIfWordIsRevealed(char[] wordToGuess)
        {
            return wordToGuess.All(ch => ch != '_');
        }

        private int CheckUserGuess(char suggestedLetter, string secretWord, char[] wordToGuess)
        {
            int numberOfRevealedLetters = 0;
            bool isLetterAlreadyRevealed = this.CheckIfLetterIsAlreadyRevealed(suggestedLetter, wordToGuess);
            if (!isLetterAlreadyRevealed)
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (suggestedLetter == secretWord[i])
                    {
                        wordToGuess[i] = suggestedLetter;
                        numberOfRevealedLetters++;
                    }
                }
            }

            return numberOfRevealedLetters;
        }

        private bool CheckIfLetterIsAlreadyRevealed(char suggestedLetter, char[] wordToGuess)
        {
            bool isLetterRevealed = false;
            foreach (char letter in wordToGuess)
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