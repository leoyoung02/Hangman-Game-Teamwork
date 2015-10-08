namespace Hangman.Logic.Contracts
{
    using Utils;
    interface IEngine
    {
        IPrinter Printer { get; set; }

        WordInitializer WordInitializer { get; set; }

        bool HasCurrentGameEnded { get; set; }

        void GetUserInput();

        bool CheckIfGameIsWon();

        bool HaveAllGamesEnded { get; set; }
    }
}
