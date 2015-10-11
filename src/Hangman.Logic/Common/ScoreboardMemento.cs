namespace Hangman.Logic.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// Holds the scoreboard state
    /// </summary>
    internal class ScoreboardMemento
    {
        /// <summary>
        /// Creates and sets the scoreboard state.
        /// </summary>
        /// <param name="topFiveRecords"></param>
        public ScoreboardMemento(List<Player> topFiveRecords)
        {
            this.TopFiveRecords = topFiveRecords;
        }

        /// <summary>
        /// The top 5 players with the best score
        /// </summary>
        public List<Player> TopFiveRecords { get; set; }
    }
}
