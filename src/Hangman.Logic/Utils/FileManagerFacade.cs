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
            // TODO move encoding logic to Encoder
            // TODO move decoding logic to Decoder
            List<Player> records = new List<Player>();

            this.CreateHiddenFileForRecords();

            string textToEncode = File.ReadAllText(FilePath);

            string encodedFile = Decoder.Base64Decode(textToEncode);

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
                    .Select(p => new Player(p[0], Convert.ToInt32(p[1])))
                    .ToList();
            }

            return records;

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

        private void CreateHiddenFileForRecords()
        {
            FileStream fs = File.Open(FilePath, FileMode.OpenOrCreate);
            fs.Close();

            File.SetAttributes(FilePath, FileAttributes.Hidden);
        }
    }
}
