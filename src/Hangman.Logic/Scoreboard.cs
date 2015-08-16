namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic;

    internal class Scoreboard
    {
        private const int MaxNumberOfRecords = 5;
        private readonly List<KeyValuePair<int, string>> topFiveRecords;

        public Scoreboard()
        {
            this.topFiveRecords = new List<KeyValuePair<int, string>>();
        }

        public void TryToSignToScoreboard(int numberOfMistakesMade)
        {
            bool scoreQualifiesForTopFive = this.CheckIfScoreQualifiesForTopFive(numberOfMistakesMade);
            if (scoreQualifiesForTopFive)
            {
                this.AddNewRecord(numberOfMistakesMade);
                this.PrintCurrentScoreboard();
            }
        }

        public void PrintCurrentScoreboard()
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
                    Console.WriteLine("{0}. {1} --> {2} mistakes", i + 1, name, mistakes);
                }
            }
        }

        private static int CompareByKeys(KeyValuePair<int, string> pairA, KeyValuePair<int, string> pairB)
        {
            return pairA.Key.CompareTo(pairB.Key);
        }

        private bool CheckIfScoreQualifiesForTopFive(int numberOfMistakesMade)
        {
            bool scoreQualifiesForTopFive = false;
            if (this.topFiveRecords.Count < MaxNumberOfRecords)
            {
                scoreQualifiesForTopFive = true;
            }
            else
            {
                int worstScoreInTopFive = this.topFiveRecords[MaxNumberOfRecords - 1].Key;
                if (numberOfMistakesMade < worstScoreInTopFive)
                {
                    scoreQualifiesForTopFive = true;
                }
            }

            return scoreQualifiesForTopFive;
        }

        private void AddNewRecord(int numberOfMistakesMade)
        {
            if (this.topFiveRecords.Count == MaxNumberOfRecords)
            {
                this.DeleteTheWorstRecord();
            }

            string playerName = this.AskForPlayerName();
            KeyValuePair<int, string> newRecord = new KeyValuePair<int, string>(numberOfMistakesMade, playerName);
            this.topFiveRecords.Add(newRecord);
            this.SortRecordsAscendingByScore();
        }

        private string AskForPlayerName()
        {
            string name = "unknown";
            bool inputIsAcceptable = false;
            while (!inputIsAcceptable)
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
                    inputIsAcceptable = true;
                }
            }

            return name;
        }

        private void DeleteTheWorstRecord()
        {
            this.topFiveRecords.RemoveAt(this.topFiveRecords.Count - 1);
        }

        private void SortRecordsAscendingByScore()
        {
            this.topFiveRecords.Sort(CompareByKeys);
        }
    }
}