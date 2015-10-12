namespace Hangman.Tests
{
    using Logic.Common;
    using Logic;
    using Logic.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class ConsolePrinterTests
    {
        public List<Player> fakeTopFiveRecords = new List<Player>()
        {
            new Player("Pesho", 2),
            new Player("Gosho", 3),
            new Player("John", 21),
        };

        [TestMethod]
        public void PrintWelcomeMessagePtintsCorrectMessage()
        {
            var printer = new ConsolePrinter();
            var expected = GlobalMessages.Welcome + Environment.NewLine +
                GlobalMessages.CommandOptions + Environment.NewLine;

            var consoleOutput = new ConsoleOutput();
            printer.PrintWelcomeMessage();
            Assert.AreEqual(expected, consoleOutput.GetOuput());

            //var fakerPrinter = new Mock<IPrinter>();
            //fakerPrinter.Setup(p => p.PrintWelcomeMessage());
            //fakerPrinter.Object.PrintWelcomeMessage();
            //fakerPrinter.Verify(p => p.PrintWelcomeMessage(), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintWordToGuessPrintsCorrectMessage()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();
            char[] wordToGuess = "tralala".ToCharArray();

            var expected = GlobalMessages.SecretWord + string.Join(" ", wordToGuess) + " " + Environment.NewLine;
            printer.PrintWordToGuess(wordToGuess);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintInvalidEntryMessagePrintsCorrectMessage()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();

            var expected = GlobalMessages.IncorrectGuessOrCommand + Environment.NewLine;
            printer.PrintInvalidEntryMessage();

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintWinMessageIsCorrectWhenHelpNotUsed()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();
            uint mistakesCount = 3;

            var mockScoreboard = new Mock<IScoreboard>();
            mockScoreboard.Setup(m => m.TopFiveRecords).Returns(this.fakeTopFiveRecords);
            char[] wordToGuess = "tralala".ToCharArray();

            var expected = GlobalMessages.SecretWord + string.Join(" ", wordToGuess) + " "
                + Environment.NewLine + string.Format(GlobalMessages.Win, mistakesCount) + Environment.NewLine;
            printer.PrintWinMessage(mistakesCount, false, mockScoreboard.Object, wordToGuess);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintWinMessageIsCorrectWhenHelpIsUsed()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();
            uint mistakesCount = 3;

            var mockScoreboard = new Mock<IScoreboard>();
            mockScoreboard.Setup(m => m.TopFiveRecords).Returns(this.fakeTopFiveRecords);
            char[] wordToGuess = "tralala".ToCharArray();

            var expected = GlobalMessages.SecretWord + string.Join(" ", wordToGuess) + " "
                + Environment.NewLine + string.Format(GlobalMessages.WinWithHelp, mistakesCount) + Environment.NewLine;
            printer.PrintWinMessage(mistakesCount, true, mockScoreboard.Object, wordToGuess);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintNumberOfRevealedLettersIsCorrectForOneLetter()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();
            int revealedLettersCount = 1;

            var expected = string.Format(GlobalMessages.OneLetterRevealed, revealedLettersCount) + Environment.NewLine;
            printer.PrintNumberOfRevealedLetters(revealedLettersCount);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintNumberOfRevealedLettersIsCorrectForManyLetters()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();
            int revealedLettersCount = 3;

            var expected = string.Format(GlobalMessages.MultipleLettersRevealed, revealedLettersCount) + Environment.NewLine;
            printer.PrintNumberOfRevealedLetters(revealedLettersCount);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintNoRevealedLettersMessageIsCorrect()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();
            char revealedLetter = 'A';

            var expected = string.Format(GlobalMessages.LetterNotRevealed, revealedLetter) + Environment.NewLine;
            printer.PrintNoRevealedLettersMessage(revealedLetter);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintEnterLetterOrCommandMessageIsCorrect()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();

            var expected = GlobalMessages.EnterLetterOrCommand;
            printer.PrintEnterLetterOrCommandMessage();

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintAllRecordsIsCorrect()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();

            var expected = GlobalMessages.HighScores + Environment.NewLine;

            for (int i = 0; i < fakeTopFiveRecords.Count; i++)
            {
                string name = fakeTopFiveRecords[i].PlayerName;
                uint mistakes = fakeTopFiveRecords[i].Score;
                expected += string.Format(GlobalMessages.ScoreFormat, i + 1, name, mistakes) + Environment.NewLine;
            }

            printer.PrintAllRecords(fakeTopFiveRecords);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void WriteVanWriteAnyMessage()
        {
            string message = "Abrakadabra";
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();

            var expected = message + Environment.NewLine;
            printer.Write(message);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }

        [TestMethod]
        public void PrintLetterAlreadyRevealedMessageIsCorrect()
        {
            var printer = new ConsolePrinter();
            var consoleOutput = new ConsoleOutput();

            var expected = "The letter you have entered is already revealed!" + Environment.NewLine;
            printer.PrintLetterAlreadyRevealedMessage();

            Assert.AreEqual(expected, consoleOutput.GetOuput());
        }
    }
}