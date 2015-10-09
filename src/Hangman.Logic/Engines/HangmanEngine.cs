namespace Hangman.Logic.Engines
{
    using System.Linq;
    using Contracts;
    using Factories;
    using Games;
    using Utils;


    public class HangmanEngine : GameEngine, IGameEngine
    {
        private HangmanGame hangmanGame;

        private int mistakes;
        public HangmanEngine(IPrinter printer, IReader inputReader, CommandFactory commandFactory, Validator validator, HangmanGame hangmanGame)
            : base(printer, inputReader, commandFactory, validator, hangmanGame)
        {
        }

        public int Mistakes
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

        public HangmanGame HangmanGame
        {
            get
            {
                return this.hangmanGame;
            }
            set
            {
                this.hangmanGame = value;
            }
        }

        public override bool CheckIfGameIsWon()
        {
            bool isWordRevealed = this.CheckIfWordIsRevealed(this.HangmanGame.WordInitializer.GuessedWordLetters);
            if (isWordRevealed)
            {
                isWordRevealed = false;
                this.HandleVictory();
            }

            return isWordRevealed;
        }
        //TODO: Not single responsibility (print, handle victory)
        public void HandleVictory()
        {
            this.Printer.PrintWordToGuess(this.HangmanGame.WordInitializer.GuessedWordLetters);
            this.Printer.PrintWinMessage(this.Mistakes, IsHelpUsed, this.Scoreboard);
            string currentPlayerName = this.AskForPlayerName();
            var player = new Player(currentPlayerName, this.Mistakes);
            this.Scoreboard.AddNewRecord(player);
            this.Printer.PrintAllRecords(this.Scoreboard.GetAllRecords());
            this.Initialize().StartGame();
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
            else
            {
                this.Printer.PrintNoRevealedLettersMessage(suggestedLetter);
                this.Mistakes++;
            }
        }

        public override void GetUserInput()
        {
            bool isInputValid = false;
            ICommand command;

            while (!isInputValid)
            {
                this.Printer.PrintEnterLetterOrCommandMessage();
                string inputCommand = InputReader.ReadLine();
                inputCommand = inputCommand.ToLower();

                if (Validator.InputCommandValidator(inputCommand))
                {
                    isInputValid = true;
                    command = CommandFactory.CreateCommand(inputCommand, this, this.HangmanGame, this.Scoreboard.TopFiveRecords);
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

            this.Printer.PrintRevealLetterMessage(letterToBeRevealed);
        }

        private bool CheckIfWordIsRevealed(char[] wordToGuess)
        {
            return wordToGuess.All(ch => ch != '_');
        }

        // TODO if user enter already revealed letter, don't count mistake and print proper message.
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

        public override IGameEngine Initialize()
        {
            this.Printer = Printer;
            this.InputReader = InputReader;
            this.CommandFactory = CommandFactory;
            this.Validator = Validator;
            this.HangmanGame = new HangmanGame(new WordInitializer());
            this.Scoreboard = Scoreboard;


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
    }
}