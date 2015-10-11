namespace Hangman.Logic
{
    using System.Collections.Generic;
    using Utils;

    public sealed class Scoreboard
    {
        internal const int MaxRecords = 5;
        private static Scoreboard instance;
        private List<Player> topFiveRecords;
        private FileManagerFacade fileManagerFacade;
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

        public List<Player> TopFiveRecords
        {
            get
            {
                return this.topFiveRecords;
            }
        }

        public void AddNewRecord(Player player)
        {
            this.TopFiveRecords.Add(player);
            memory.ScoreboardMemento = this.SaveTopFive();
            this.SaveRecordsToFile(memory.ScoreboardMemento);
        }

        public List<Player> GetAllRecords()
        {
            return this.TopFiveRecords;
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
