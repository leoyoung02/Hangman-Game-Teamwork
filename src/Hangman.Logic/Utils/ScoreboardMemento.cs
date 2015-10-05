using System.Collections.Generic;

namespace Hangman.Logic.Utils
{
    internal class ScoreboardMemento
    {
        public ScoreboardMemento(List<Player> topFiveRecords)
        {
            this.TopFiveRecords = topFiveRecords;
        }

        public List<Player> TopFiveRecords { get; set; }
    }
}
