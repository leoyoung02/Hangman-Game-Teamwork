namespace Hangman.Logic
{
    using System.Collections.Generic;
    using Utils;

    /// <summary>
    /// Stores the top 5 players and their scores
    /// </summary>
    public sealed class Scoreboard
    {
        internal const int MaxRecords = 5;
        private static Scoreboard instance;
        private List<Player> topFiveRecords;
        private readonly FileManagerFacade fileManagerFacade;
        private readonly ProspectMemory memory;

        private Scoreboard()
        {
            this.topFiveRecords = new List<Player>();
            this.fileManagerFacade = new FileManagerFacade();
            memory = new ProspectMemory();
            memory.ScoreboardMemento = new ScoreboardMemento(topFiveRecords);
            memory.ScoreboardMemento = this.LoadRecords();
            this.RestoreTopFive(memory.ScoreboardMemento);
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
        public List<Player> TopFiveRecords
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
        // TODO: should check player count before adding
        public void AddNewRecord(Player player)
        {
            this.TopFiveRecords.Add(player);
            memory.ScoreboardMemento = this.SaveTopFive();
            this.SaveRecordsToFile(memory.ScoreboardMemento);
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
