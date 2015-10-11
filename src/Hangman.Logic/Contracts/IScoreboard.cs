namespace Hangman.Logic.Contracts
{
    using System.Collections.Generic;

    public interface IScoreboard
    {
        List<Player> TopFiveRecords { get; }

        void AddNewRecord(Player player);
    }
}
