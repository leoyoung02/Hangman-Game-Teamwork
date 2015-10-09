namespace Hangman.Logic.Contracts
{
    using System.Collections.Generic;
    using Utils;

    public interface IPrinter
    {
        void PrintAllRecords(List<Player> topFiveRecords);
        void PrintEnterLetterOrCommandMessage();
        void PrintInvalidEntryMessage();
        void PrintNoRevealedLettersMessage(char suggestedLetter);
        void PrintNumberOfRevealedLetters(int numberOfRevealedLetters);
        void PrintRevealLetterMessage(char letterToBeRevealed);
        void PrintWelcomeMessage();
        void PrintWinMessage(int mistakesCount, bool isHelpUsed, Scoreboard scoreboard);
        void PrintWordToGuess(char[] wordToGuess);
        void Write(string message);
        void PrintWordToGuess(WordInitializer wordInitializer);
    }
}