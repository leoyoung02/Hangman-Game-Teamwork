namespace Hangman.Logic.Engines
{
    using Common;
    using Contracts;
    using Factories;
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

        public Scoreboard Scoreboard { get; set; }

        public IPrinter Printer { get; set; }

        public IReader InputReader { get; set; }

        public CommandFactory CommandFactory { get; set; }

        public Validator Validator { get; set; }

        public bool HaveAllGamesEnded { get; set; }

        public bool HasCurrentGameEnded { get; set; }

        public bool IsHelpUsed { get; set; }    

        public Game Game { get; set; }

        protected string AskForPlayerName()
        {
            bool isValid = false;
            string playerName = string.Empty;

            this.Printer.Write(GlobalMessages.PlayerNameForScoreBoard);

            while (!isValid)
            {
                playerName = InputReader.ReadLine();

                if (Validator.PlayerNameIsNullOrWhiteSpace(playerName))
                {
                    this.Printer.Write(GlobalMessages.PlayerNoNameEntered);
                }
                else if (Validator.PlayerNameIsTooLong(playerName))
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