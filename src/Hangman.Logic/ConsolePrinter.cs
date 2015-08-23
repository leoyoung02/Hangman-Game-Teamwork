namespace Hangman.Logic
{
    using System;
    using System.Collections.Generic;
    using Hangman.Logic.Common;

    internal class ConsolePrinter
    {
        internal ConsolePrinter()
        {
        }

        internal void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GlobalMessages.Welcome);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(GlobalMessages.CommandOptions);
            Console.ResetColor();
        }

        internal void PrintWordToGuess(char[] wordToGuess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GlobalMessages.SecretWord);
            foreach (var letter in wordToGuess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} ", letter);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
        }

        internal void PrintInvalidEntryMessage()
        {
            Console.WriteLine(GlobalMessages.IncorrectGuessOrCommand);
        }

        internal void PrintWinMessage(int mistakesCount, bool isHelpUsed, Scoreboard scoreboard)
        {
            if (isHelpUsed)
            {
                Console.WriteLine(GlobalMessages.WinWithHelp, mistakesCount);
            }
            else
            {
                Console.WriteLine(GlobalMessages.Win, mistakesCount);
                scoreboard.TryToSign(mistakesCount);
            }
        }

        internal void PrintNumberOfRevealedLetters(int numberOfRevealedLetters)
        {
            if(numberOfRevealedLetters == 1)
            {
                Console.WriteLine(GlobalMessages.OneLetterRevealed, numberOfRevealedLetters);
            }
            else
            {
                Console.WriteLine(GlobalMessages.MultipleLettersRevealed, numberOfRevealedLetters);
            }
        }

        internal void PrintNoRevealedLettersMessage(char suggestedLetter)
        {
            var uppercaseSuggestedLetter = char.ToUpper(suggestedLetter);
            Console.WriteLine(GlobalMessages.LetterNotRevealed, uppercaseSuggestedLetter);        
        }

        internal void PrintEnterLetterOrCommandMessage()
        {
            Console.Write(GlobalMessages.EnterLetterOrCommand);            
        }

        internal void PrintRevealLetterMessage(char letterToBeRevealed)
        {
            Console.WriteLine(GlobalMessages.HelpRevealLetter, letterToBeRevealed);        
        }

        public void PrintAllRecords(List<KeyValuePair<int, string>> topFiveRecords)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(GlobalMessages.HighScores);
            if (topFiveRecords.Count != 0)
            {
                for (int i = 0; i < topFiveRecords.Count; i++)
                {
                    string name = topFiveRecords[i].Value;
                    int mistakes = topFiveRecords[i].Key;
                    Console.WriteLine(GlobalMessages.ScoreFormat, i + 1, name, mistakes);
                }
            }
            else
            {
                Console.WriteLine(GlobalMessages.NoScoresYet);
            }
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
