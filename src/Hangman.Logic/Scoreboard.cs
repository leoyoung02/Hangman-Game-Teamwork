namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal sealed class Scoreboard
    {
        private const int MaxRecords = 5;
        private static Scoreboard instance;
        private List<KeyValuePair<int, string>> topFiveRecords;
        private ConsolePrinter printer;

        private Scoreboard()
        {
            this.topFiveRecords = this.LoadRecords();
            this.printer = new ConsolePrinter();
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

        public void TryToSign(int mistakes)
        {
            bool isScoreQualifiedForTopFive = this.CheckIfScoreIsQualifiedForTopFive(mistakes);
            if (isScoreQualifiedForTopFive)
            {
                this.AddNewRecord(mistakes);
                this.printer.PrintAllRecords(this.topFiveRecords);
            }
        }

        private List<KeyValuePair<int, string>> LoadRecords()
        {
            List<KeyValuePair<int, string>> records = new List<KeyValuePair<int, string>>();
            if (!File.Exists("HighScores.txt"))
            {
                File.Create("HighScores.txt");
                return records;
            }

            string encodedFile = this.Base64Decode(File.ReadAllText("HighScores.txt"));
            if (!string.IsNullOrEmpty(encodedFile))
            {
                string[] encodedLines = encodedFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                string[] decodedLines = new string[encodedLines.Length];
                for (int i = 0; i < encodedLines.Length; i++)
                {
                    decodedLines[i] = this.Base64Decode(encodedLines[i]);
                }

                records = decodedLines
                    .Select(l => Regex.Split(l, @"=([0-9]+)", RegexOptions.RightToLeft))
                    .ToDictionary(a => Convert.ToInt32(a[1]), a => a[0])
                    .ToList();
            }

            return records;
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private bool CheckIfScoreIsQualifiedForTopFive(int mistakes)
        {
            bool isScoreQualified = false;
            if (this.topFiveRecords.Count < MaxRecords)
            {
                isScoreQualified = true;
            }
            else
            {
                int worstScoreInTopFive = this.topFiveRecords[MaxRecords - 1].Key;
                if (mistakes < worstScoreInTopFive)
                {
                    isScoreQualified = true;
                }
            }

            return isScoreQualified;
        }

        private void AddNewRecord(int mistakes)
        {
            if (this.topFiveRecords.Count == MaxRecords)
            {
                this.DeleteWorstRecord();
            }

            string playerName = this.AskForPlayerName();
            KeyValuePair<int, string> newRecord = new KeyValuePair<int, string>(mistakes, playerName);
            this.topFiveRecords.Add(newRecord);
            this.SortRecordsAscendingByScore();
            this.SaveRecordsToFile();
        }

        private void DeleteWorstRecord()
        {
            this.topFiveRecords.RemoveAt(this.topFiveRecords.Count - 1);
        }

        private string AskForPlayerName()
        {
            string name = "unknown";
            bool isInputValid = false;
            while (!isInputValid)
            {
                this.printer.Write("Please enter your name for the top scoreboard: ");
                string line = Console.ReadLine();
                if (line.Length == 0)
                {
                    this.printer.Write("You did not enter a name. Please, try again.");
                }
                else if (line.Length > 40)
                {
                    this.printer.Write("The name you entered is too long. Please, enter a name up to 40 characters");
                }
                else
                {
                    name = line;
                    isInputValid = true;
                }
            }

            return name;
        }

        private void SortRecordsAscendingByScore()
        {
            this.topFiveRecords.Sort(this.CompareByKeys);
        }

        private int CompareByKeys(KeyValuePair<int, string> pairA, KeyValuePair<int, string> pairB)
        {
            return pairA.Key.CompareTo(pairB.Key);
        }

        private void SaveRecordsToFile()
        {
            string[] lines = this.topFiveRecords
                .Select(kvp => kvp.Value + "=" + kvp.Key)
                .ToArray();

            string[] encodedLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                encodedLines[i] = this.Base64Encode(lines[i]);
            }

            string encodedFile = this.Base64Encode(string.Join(Environment.NewLine, encodedLines));
            File.WriteAllText("HighScores.txt", encodedFile);
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}