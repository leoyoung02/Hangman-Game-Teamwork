namespace Hangman.Logic.Engines
{
    using System.Linq;
    using Contracts;
    using Factories;
    using Games;
    using Utils;

    public class HangmanEngine : GameEngine, IGameEngine
    {
        private const int NumberOfAlreadyRevealedLetters = -1;
 
        public HangmanEngine(IPrinter printer, IReader inputReader, CommandFactory commandFactory, Validator validator, HangmanGame hangmanGame)
            : base(printer, inputReader, commandFactory, validator, hangmanGame)
        {
        }

        public uint Mistakes { get; set; }

        public HangmanGame HangmanGame { get; set; }

        public override IGameEngine Initialize()
        {
            this.HangmanGame = new HangmanGame(new WordInitializer());

            return this;
        }

        public override bool StartGame()
        {
            this.Printer.PrintWelcomeMessage();
            while (!this.HasCurrentGameEnded)
            {
                this.Printer.PrintWordToGuess(this.HangmanGame.WordInitializer.GuessedWordLetters);
                this.GetUserInput();

                bool isGameWon = this.CheckIfGameIsWon();
                if (isGameWon)
                {
                    this.HasCurrentGameEnded = true;
                }
            }

            return this.HaveAllGamesEnded;
        }

        public override bool CheckIfGameIsWon()
        {
            bool isWordRevealed = this.CheckIfWordIsRevealed(this.HangmanGame.WordInitializer.GuessedWordLetters);
            if (isWordRevealed)
            {
                isWordRevealed = false;
                this.Printer.PrintWinMessage(this.Mistakes, this.IsHelpUsed, this.Scoreboard, this.HangmanGame.WordInitializer.GuessedWordLetters);
                this.HandleVictory();
                this.Printer.PrintAllRecords(this.Scoreboard.TopFiveRecords);
                this.Initialize().StartGame();
            }

            return isWordRevealed;
        }

        public void HandleVictory()
        {
            if (!this.IsHelpUsed)
            {
                string currentPlayerName = this.AskForPlayerName();
                var player = new Player(currentPlayerName, this.Mistakes);
                this.Scoreboard.AddNewRecord(player);
            }
        }

        public override void GetUserInput()
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                this.Printer.PrintEnterLetterOrCommandMessage();
                string inputCommand = InputReader.ReadLine();

                if (Validator.InputCommandIsValid(inputCommand))
                {
                    isInputValid = true;
                    ICommand command = CommandFactory.CreateCommand(inputCommand);
                    command.Execute(this);
                }
                else
                {
                    this.Printer.PrintInvalidEntryMessage();
                }
            }
        }

        internal void ProcessUserGuess(char suggestedLetter)
        {
            int numberOfRevealedLetters = this.CheckUserGuess(suggestedLetter, this.HangmanGame.WordInitializer.Word, this.HangmanGame.WordInitializer.GuessedWordLetters);
            if (numberOfRevealedLetters > 0)
            {
                bool isWordRevealed = this.CheckIfWordIsRevealed(this.HangmanGame.WordInitializer.GuessedWordLetters);
                if (!isWordRevealed)
                {
                    this.Printer.PrintNumberOfRevealedLetters(numberOfRevealedLetters);
                }
            }
            else if (numberOfRevealedLetters == NumberOfAlreadyRevealedLetters)
            {
                this.Printer.PrintLetterAlreadyRevealedMessage();
            }
            else
            {
                this.Printer.PrintNoRevealedLettersMessage(suggestedLetter);
                this.Mistakes++;
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

            this.Printer.PrintRevealLetterMessage(letterToBeRevealed);
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
            else
            {
                numberOfRevealedLetters = NumberOfAlreadyRevealedLetters;
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
