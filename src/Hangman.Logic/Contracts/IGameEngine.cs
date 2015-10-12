namespace Hangman.Logic.Contracts
{
    /// <summary>
    ///  Abstraction for the main engine of the game.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        ///  Instance of abstract class Game.
        /// </summary>
        Game Game { get; set; }

        /// <summary>
        ///   Property for accessing the printing device.  
        /// </summary>
        IPrinter Printer { get; set; }

        /// <summary>
        ///     Property that holds information about the current game's status.
        /// </summary>
        bool HasCurrentGameEnded { get; set; }

        /// <summary>
        ///   Property that holds information about all games' status. 
        /// </summary>
        bool HaveAllGamesEnded { get; set; }

        /// <summary>
        ///     Method for handling user's input.
        /// </summary>
        void GetUserInput();

        /// <summary>
        ///  Method that checks current game's status.
        /// </summary>
        /// <returns></returns>
        bool CheckIfGameIsWon();

        /// <summary>
        ///  Method to start the main game logic
        /// </summary>
        /// <returns></returns>
        bool StartGame();

        /// <summary>
        ///     Method to initialize the main game logic. Create instances of required classes.
        /// </summary>
        /// <returns></returns>
        IGameEngine Initialize();
    }
}