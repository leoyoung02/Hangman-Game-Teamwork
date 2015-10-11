namespace Hangman.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    /// <summary>
    /// Stores the top 5 players and their scores
    /// </summary>
    public sealed class Scoreboard
    {
        public const int MaxRecords = 5;
        private static Scoreboard instance;
        private readonly FileManagerFacade fileManagerFacade;
        private readonly ProspectMemory memory;
        private List<Player> topFiveRecords;

        private Scoreboard()
        {
            this.topFiveRecords = new List<Player>();
            this.fileManagerFacade = new FileManagerFacade();
            this.memory = new ProspectMemory();
            this.memory.ScoreboardMemento = new ScoreboardMemento(this.topFiveRecords);
            this.memory.ScoreboardMemento = this.LoadRecords();
            this.RestoreTopFive(this.memory.ScoreboardMemento);
        }

        /// <summary>
        /// Get/Set Scoreboard instance (lazy loading).
        /// </summary>
        public static Scoreboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scoreboard();
                }

                return instance;
            }
        }

        /// <summary>
        /// List of top 5 players
        /// </summary>
        public List<Player> TopFiveRecords // TODO: should be sorted
        {
            get
            {
                return this.topFiveRecords;
            }
        }

        /// <summary>
        /// Adds a new player to TopFiveRecords
        /// </summary>
        /// <param name="player">The Player instance to be added</param>
        public void AddNewRecord(Player player) // TODO: should check player count before adding
        {
            this.TopFiveRecords.Add(player);

            this.topFiveRecords.Sort(
                                delegate(Player p1, Player p2)
                                {
                                 return p1.Score.CompareTo(p2.Score);
                                });

            this.topFiveRecords = this.topFiveRecords.Take(5).ToList();

            this.memory.ScoreboardMemento = this.SaveTopFive();
            this.SaveRecordsToFile(this.memory.ScoreboardMemento);
        }

        private ScoreboardMemento LoadRecords()
        {
            List<Player> records = new List<Player>();

            records = this.fileManagerFacade.LoadRecords();

            return new ScoreboardMemento(records);
        }

        private void RestoreTopFive(ScoreboardMemento memento)
        {
            this.topFiveRecords = memento.TopFiveRecords;
        }

        private ScoreboardMemento SaveTopFive()
        {
            return new ScoreboardMemento(this.TopFiveRecords);
        }

        private void SaveRecordsToFile(ScoreboardMemento memento)
        {
            this.fileManagerFacade.SaveRecordsToFile(memento);
        }
    }
}
