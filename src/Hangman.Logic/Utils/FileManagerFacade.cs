namespace Hangman.Logic.Utils
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    ///  Implements Facade Design Pattern for better use of operations with files.
    /// </summary>
    internal class FileManagerFacade
    {
        private const string FilePath = "HighScores.txt";

        public FileManagerFacade()
        {
        }

        /// <summary>
        ///     Extracts data about players and their scores from file.
        /// </summary>
        /// <returns>List of players</returns>
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
                    .Select(p => new Player(p[0], uint.Parse(p[1])))
                    .ToList();
            }

            return records;
        }

        /// <summary>
        ///     Save the top five players that are holded in the scoreboard instance to file.
        /// </summary>
        /// <param name="memento">Instance of scoreboard that holds information about the top five players.</param>
        public void SaveRecordsToFile(ScoreboardMemento memento)
        {
            string encodedFile = Encoder.GetEncodedFile(memento);

            // Display file so it can be written in and hide it again
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) & ~FileAttributes.Hidden);
            File.WriteAllText(FilePath, encodedFile);
            File.SetAttributes(FilePath, File.GetAttributes(FilePath) | FileAttributes.Hidden);
        }

        private void CreateHiddenFileForRecords()
        {
            FileStream fs = File.Open(FilePath, FileMode.OpenOrCreate);
            fs.Close();

            File.SetAttributes(FilePath, FileAttributes.Hidden);
        }
    }
}