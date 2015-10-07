namespace Hangman.Logic.Utils
{
    using System.Collections.Generic;
    internal class ScoreboardMemento
    {
        public ScoreboardMemento(List<Player> topFiveRecords)
        {
            this.TopFiveRecords = topFiveRecords;
        }

        public List<Player> TopFiveRecords { get; set; }
    }
}
