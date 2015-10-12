namespace Hangman.Logic.Engines
{
    using Common;
    using Contracts;
    using Factories;
    using Utils;

    /// <summary>
    ///  Holds key information and logic required for engines.
    /// </summary>
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

        /// <summary>
        ///  Holds Instance of the Scoreboard class that holds information about players.
        /// </summary>
        public Scoreboard Scoreboard { get; set; }

        /// <summary>
        ///  Property that holds the selected printer. Could be console or graphical printer.
        /// </summary>
        public IPrinter Printer { get; set; }

        /// <summary>
        ///  Property for the class that handles users' input commands
        /// </summary>
        public IReader InputReader { get; set; }

        /// <summary>
        ///  Property for the class that generates commands.
        /// </summary>
        public CommandFactory CommandFactory { get; set; }

        /// <summary>
        ///  Property for the class that ensures valid data is passed.
        /// </summary>
        public Validator Validator { get; set; }

        /// <summary>
        ///  Property that holds all games' status
        /// </summary>
        public bool HaveAllGamesEnded { get; set; }

        /// <summary>
        ///  Property that holds current game's status
        /// </summary>
        public bool HasCurrentGameEnded { get; set; }

        /// <summary>
        ///  Property that checks if help is used
        /// </summary>
        public bool IsHelpUsed { get; set; }    

        /// <summary>
        ///  Instance of the abstract class Game.
        /// </summary>
        public Game Game { get; set; }

        public abstract bool CheckIfGameIsWon();

        public abstract void GetUserInput();

        public abstract bool StartGame();

        public abstract IGameEngine Initialize();

        protected string AskForPlayerName()
        {
            bool isValid = false;
            string playerName = string.Empty;

            this.Printer.Write(GlobalMessages.PlayerNameForScoreBoard);

            while (!isValid)
            {
                playerName = this.InputReader.ReadLine();

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
    }
}