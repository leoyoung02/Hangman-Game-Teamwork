namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic;

    internal class ConsolePrinter
    {
        internal ConsolePrinter()
        {
        }

        internal void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                "<< Welcome to “Hangman” game >>\n" +
                "<< Please try to guess the secret word >>\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
                "Commands:\n" +
                "HELP \t\t Reveals a letter.\n" +
                "TOP \t\t Displays high scores.\n" +
                "RESTART \t Starts a new game.\n" +
                "EXIT \t\t Quits the game.");
            Console.ResetColor();
        }

        internal void PrintDisplayableWord(char[] displayableWord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nThe secret word is: ");
            foreach (var letter in displayableWord)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", letter);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
        }

        internal void PrintInvalidEntryMessage()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        internal void PrintWinWithCheatMessage(int mistakesCount)
        {
            Console.WriteLine(
                       "You won with {0} mistakes but you have cheated. " +
                       "You are not allowed to enter into the scoreboard.",
                       mistakesCount);
        }

        internal void PrintWinMessage(int mistakesCount, bool isHelpUsed, Scoreboard scoreboard)
        {
            if (isHelpUsed)
            {
                Console.WriteLine(
                        "You won with {0} mistakes but you have cheated. " +
                        "You are not allowed to enter into the scoreboard.",
                        mistakesCount);
            }
            else
            {
                Console.WriteLine("You won with {0} mistakes.", mistakesCount);
                scoreboard.TryToSign(mistakesCount);
            }
        }

        internal void PrintNumberOfRevealedLetters(int numberOfRevealedLetters)
        {
            Console.WriteLine(
                numberOfRevealedLetters == 1
                    ? "Good job! You revealed {0} letter."
                    : "Good job! You revealed {0} letters.",
                    numberOfRevealedLetters);            
        }

        internal void PrintNoRevealedLettersMessage(char suggestedLetter)
        {
            Console.WriteLine("Sorry! There are no revealed letters \"{0}\".", suggestedLetter);        
        }

        internal void PrintEnterLetterOrCommandMessage()
        {
            Console.Write("\nEnter your guess letter or command: ");            
        }

        internal void PrintRevealLetterMessage(char letterToBeRevealed)
        {
            Console.WriteLine("OK, let's reveal for you the next letter '{0}'.", letterToBeRevealed);        
        }

        public void PrintAllRecords(List<KeyValuePair<int, string>> topFiveRecords)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nHigh scores:");
            if (topFiveRecords.Count != 0)
            {
                for (int i = 0; i < topFiveRecords.Count; i++)
                {
                    string name = topFiveRecords[i].Value;
                    int mistakes = topFiveRecords[i].Key;
                    Console.WriteLine("({0}) {1} - {2} mistakes", i + 1, name, mistakes);
                }
            }
            else
            {
                Console.WriteLine("There are no records in the scoreboard yet.");
            }
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
