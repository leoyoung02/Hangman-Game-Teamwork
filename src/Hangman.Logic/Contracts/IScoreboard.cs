namespace Hangman.Logic.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    ///  Contract for execution the handling of the main data.
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        ///  Property to access the saved five players with highest score.
        /// </summary>
        List<Player> TopFiveRecords { get; }

        /// <summary>
        ///     Add new player to the list of top five players.
        /// </summary>
        /// <param name="player"></param>
        void AddNewRecord(Player player);
    }
}
