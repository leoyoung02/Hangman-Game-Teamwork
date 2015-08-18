namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic;

    internal sealed class Scoreboard
    {
        private const int MaxRecords = 5;
        private static Scoreboard instance;
        private readonly List<KeyValuePair<int, string>> topFiveRecords;

        private Scoreboard()
        {
            this.topFiveRecords = new List<KeyValuePair<int, string>>();
        }

        internal static Scoreboard Instance
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
                this.PrintAllRecords();
            }
        }

        public void PrintAllRecords()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nScoreboard:");
            if (this.topFiveRecords.Count == 0)
            {
                Console.WriteLine("There are no records in the scoreboard yet.");
            }
            else
            {
                for (int i = 0; i < this.topFiveRecords.Count; i++)
                {
                    string name = this.topFiveRecords[i].Value;
                    int mistakes = this.topFiveRecords[i].Key;
                    Console.WriteLine("({0}) {1} --> {2} mistakes", i + 1, name, mistakes);
                }
            }
        }

        private int CompareByKeys(KeyValuePair<int, string> pairA, KeyValuePair<int, string> pairB)
        {
            return pairA.Key.CompareTo(pairB.Key);
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
                Console.Write("Please enter your name for the top scoreboard: ");
                string line = Console.ReadLine();
                if (line.Length == 0)
                {
                    Console.WriteLine("You did not enter a name. Please, try again.");
                }
                else if (line.Length > 40)
                {
                    Console.WriteLine("The name you entered is too long. Please, enter a name up to 40 characters");
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
    }
}