namespace Hangman.Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class FileManagerFacade
    {
        private const string FilePath = "HighScores.txt";

        public FileManagerFacade()
        {
        }

        public List<Player> LoadRecords()
        {
            List<Player> records = new List<Player>();

            this.CreateHiddenFileForRecords();

            string textToDecode = File.ReadAllText(FilePath);

            string decodedText = Decoder.Base64Decode(textToDecode);

            if (!string.IsNullOrEmpty(decodedText))
            {
                string[] decodedLines = Decoder.DecodeEveryLine(decodedText);

                records = decodedLines
                    .Select(l => Regex.Split(l, @"=([0-9]+)", RegexOptions.RightToLeft))
                    .Select(p => new Player(p[0], Convert.ToInt32(p[1])))
                    .ToList();
            }

            return records;
            // TODO: Remove unnecessary comments
            //var x = new XmlSerializer(this.TopFiveRecords.GetType());
            //if (File.Exists(FilePath))
            //{
            //    var file = new StreamReader(FilePath);
            //     memory.ScoreboardMemento = (ScoreboardMemento)x.Deserialize(file);
            //}

            //return memory.ScoreboardMemento;
        }

        public void SaveRecordsToFile(ScoreboardMemento memento)
        {
            string encodedFile = Encoder.GetEncodedFile(memento);

            // Display file so it can be written in and hide it again

            File.SetAttributes(FilePath, File.GetAttributes(FilePath) & ~FileAttributes.Hidden);
            File.WriteAllText(FilePath, encodedFile);
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.Hidden);

            //var x = new XmlSerializer(memento.GetType());
            //var file = new StreamWriter(FilePath);
            //x.Serialize(file, memento);
            //file.Close();
        }

        private void CreateHiddenFileForRecords()
        {
            FileStream fs = File.Open(FilePath, FileMode.OpenOrCreate);
            fs.Close();

            File.SetAttributes(FilePath, FileAttributes.Hidden);
        }
    }
}