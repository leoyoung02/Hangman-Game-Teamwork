namespace Hangman.Logic.Contracts
{
    using Utils;

    internal interface IEngine
    {
        IPrinter Printer { get; set; }

        WordInitializer WordInitializer { get; set; }

        bool HasCurrentGameEnded { get; set; }

        bool HaveAllGamesEnded { get; set; }

        void GetUserInput();

        bool CheckIfGameIsWon();
    }
}
