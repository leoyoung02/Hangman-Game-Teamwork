namespace Hangman.Logic.Engines
{
    using Common;
    using Contracts;
    using Factories;
    using System;
    using Utils;

    public abstract class GameEngine : IGameEngine
    {
        private Scoreboard scoreboard;
        private Validator validator;
        private IReader inputReader;
        private CommandFactory commandFactory;
        private IPrinter printer;
        private bool haveAllGamesEnded;
        private bool hasCurrentGameEnded;
        private bool isHelpUsed;
        private Game game;

        public GameEngine(IPrinter printer, IReader inputReader, CommandFactory commandFactory, Validator validator, Game game)
        {
            this.Scoreboard = Scoreboard.Instance;
            this.Printer = printer;
            this.InputReader = inputReader;
            this.CommandFactory = commandFactory;
            this.Validator = validator;
            this.Game = game;
        }

        public bool HaveAllGamesEnded
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

        public bool HasCurrentGameEnded
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

        public Scoreboard Scoreboard
        {
            get
            {
                return this.scoreboard;
            }

            set
            {
                scoreboard = value;
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

        public CommandFactory CommandFactory
        {
            get
            {
                return this.commandFactory;
            }

            set
            {
                this.commandFactory = value;
            }
        }

        public IPrinter Printer
        {
            get
            {
                return this.printer;
            }

            set
            {
                this.printer = value;
            }
        }

        public Validator Validator
        {
            get
            {
                return this.validator;
            }

            set
            {
                this.validator = value;
            }
        }

        public IReader InputReader
        {
            get
            {
                return this.inputReader;
            }

            set
            {
                this.inputReader = value;
            }
        }

        public Game Game
        {
            get
            {
                return this.game;
            }

            set
            {
                this.game = value;
            }
        }

        protected string AskForPlayerName()
        {
            bool isValid = false;
            string playerName = string.Empty;

            this.Printer.Write(GlobalMessages.PlayerNameForScoreBoard);

            while (!isValid)
            {
                playerName = InputReader.ReadLine();

                if (validator.PlayerNameIsNullOrWhiteSpace(playerName))
                {
                    this.Printer.Write(GlobalMessages.PlayerNoNameEntered);
                }
                else if (validator.PlayerNameIsTooLong(playerName))
                {
                    this.Printer.Write(GlobalMessages.PlayerNameTooLong);
                }
                else
                {
                    isValid = true;
                }
            }

            return playerName;
        }
        public abstract bool CheckIfGameIsWon();

        public abstract void GetUserInput();

        public abstract bool StartGame();

        public abstract IGameEngine Initialize();
    }
}