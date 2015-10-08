namespace Hangman.Logic.Contracts
{
    interface IEngine
    {
        IPrinter Printer { get; set; }

        bool HasCurrentGameEnded { get; set; }

        void GetUserInput();

        bool CheckIfGameIsWon();

        bool HaveAllGamesEnded { get; set; }
    }
}
