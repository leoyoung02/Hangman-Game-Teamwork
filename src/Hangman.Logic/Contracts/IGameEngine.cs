namespace Hangman.Logic.Contracts
{
    public interface IGameEngine
    {
        Game Game { get; set; }

        IPrinter Printer { get; set; }

        bool HasCurrentGameEnded { get; set; }

        bool HaveAllGamesEnded { get; set; }

        void GetUserInput();

        bool CheckIfGameIsWon();

        bool StartGame();

        IGameEngine Initialize();
    }
}