namespace Hangman.Logic.Contracts
{
    public interface IGameEngine
    {
        Game Game { get; set; }

        IPrinter Printer { get; set; }

        bool HasCurrentGameEnded { get; set; }

        void GetUserInput();

        bool CheckIfGameIsWon();

        bool HaveAllGamesEnded { get; set; }

        bool StartGame();

        IGameEngine Initialize();
    }
}
