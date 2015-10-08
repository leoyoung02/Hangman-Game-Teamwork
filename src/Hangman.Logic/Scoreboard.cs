namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts;
    using Utils;

    internal sealed class Scoreboard
    {
        internal const int MaxRecords = 5;
        private static Scoreboard instance;
        private List<Player> topFiveRecords;
        private const string FilePath = "HighScores.txt";
        private readonly IPrinter printer;
        private readonly ProspectMemory memory;

        private Scoreboard()
        {
            this.topFiveRecords = new List<Player>();
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
            this.topFiveRecords.Add(player);
            memory.ScoreboardMemento = this.SaveTopFive();
            this.SaveRecordsToFile(memory.ScoreboardMemento);
        }

        public List<Player> GetAllRecords()
        {
            return this.topFiveRecords;
        }

        private ScoreboardMemento LoadRecords()
        {
            List<Player> records = new List<Player>();
            //TODO move encoding logic to Encoder
            //TODO move decoding logic to Decoder
            // Creating a hidden file for HighScore
            FileStream fs = File.Open(FilePath, FileMode.OpenOrCreate);
            fs.Close();
            File.SetAttributes(FilePath, FileAttributes.Hidden);

            string encodedFile = Decoder.Base64Decode(File.ReadAllText(FilePath));
            if (!string.IsNullOrEmpty(encodedFile))
            {
                string[] encodedLines = encodedFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                string[] decodedLines = new string[encodedLines.Length];
                for (int i = 0; i < encodedLines.Length; i++)
                {
                    decodedLines[i] = Decoder.Base64Decode(encodedLines[i]);
                }

                records = decodedLines
                    .Select(l => Regex.Split(l, @"=([0-9]+)", RegexOptions.RightToLeft))
                    .Select(p => new Player(p[0], Convert.ToInt32(p[1]), this.printer))
                    .ToList();
            }

            return new ScoreboardMemento(records);

            //var x = new XmlSerializer(this.TopFiveRecords.GetType());
            //if (File.Exists(FilePath))
            //{
            //    var file = new StreamReader(FilePath);
            //     memory.ScoreboardMemento = (ScoreboardMemento)x.Deserialize(file);
            //}
            
            //return memory.ScoreboardMemento;
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
            string[] lines = memento.TopFiveRecords
                .Select(p => p.PlayerName + "=" + p.Score)
                .ToArray();

            string[] encodedLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                encodedLines[i] = Encoder.Base64Encode(lines[i]);
            }

            string encodedFile = Encoder.Base64Encode(string.Join(Environment.NewLine, encodedLines));

            // Display file so it can be written in and hide it again

            File.SetAttributes(FilePath, File.GetAttributes(FilePath) & ~FileAttributes.Hidden);
            File.WriteAllText(FilePath, encodedFile);
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.Hidden);

            //var x = new XmlSerializer(memento.GetType());
            //var file = new StreamWriter(FilePath);
            //x.Serialize(file, memento);
            //file.Close();
        }
    }
}
