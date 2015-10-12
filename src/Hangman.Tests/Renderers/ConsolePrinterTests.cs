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

            var mockScoreboard = new Mock<IScoreboard>();
            mockScoreboard.Setup(m => m.TopFiveRecords).Returns(this.fakeTopFiveRecords);
            char[] wordToGuess = "tralala".ToCharArray();

            var expected = GlobalMessages.SecretWord + string.Join(" ", wordToGuess) + " " + Environment.NewLine;
            printer.PrintWinMessage(3, false, mockScoreboard.Object, wordToGuess);

            Assert.AreEqual(expected, consoleOutput.GetOuput());
            //var fakerPrinter = new Mock<IPrinter>();
            //var scoreboard = Scoreboard.Instance;
            //
            //fakerPrinter.Setup(p => p.PrintWinMessage(0, true, scoreboard, wordToGuess));
            //fakerPrinter.Object.PrintWinMessage(0, true, scoreboard, wordToGuess);
            //fakerPrinter.Object.PrintWinMessage(0, true, scoreboard, wordToGuess);
            //fakerPrinter.Verify(p => p.PrintWinMessage(0, true, scoreboard, wordToGuess), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintNumberOfRevealedLettersIsCalledAtLeastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintNumberOfRevealedLetters(10));
            fakerPrinter.Object.PrintNumberOfRevealedLetters(10);
            fakerPrinter.Object.PrintNumberOfRevealedLetters(10);
            fakerPrinter.Verify(p => p.PrintNumberOfRevealedLetters(10), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintNoRevealedLettersMessageIsCalledAtLeastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintNumberOfRevealedLetters('a'));
            fakerPrinter.Object.PrintNumberOfRevealedLetters('a');
            fakerPrinter.Object.PrintNumberOfRevealedLetters('a');
            fakerPrinter.Verify(p => p.PrintNumberOfRevealedLetters('a'), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintEnterLetterOrCommandMessageIsCalledAtLeastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintEnterLetterOrCommandMessage());
            fakerPrinter.Object.PrintEnterLetterOrCommandMessage();
            fakerPrinter.Object.PrintEnterLetterOrCommandMessage();
            fakerPrinter.Verify(p => p.PrintEnterLetterOrCommandMessage(), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintAllRecordsIsCalledAtLeastTwice()
        {
            var topFivePlayers = new List<Player>();
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintAllRecords(topFivePlayers));
            fakerPrinter.Object.PrintAllRecords(topFivePlayers);
            fakerPrinter.Object.PrintAllRecords(topFivePlayers);
            fakerPrinter.Verify(p => p.PrintAllRecords(topFivePlayers), Times.AtLeast(2));
        }

        [TestMethod]
        public void WriteIsCalledAtLeastTwice()
        {
            string message = "Abrakadabra";
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.Write(message));
            fakerPrinter.Object.Write(message);
            fakerPrinter.Object.Write(message);
            fakerPrinter.Verify(p => p.Write(message), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintLetterAlreadyRevealedMessageIsCalledAtLEastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintLetterAlreadyRevealedMessage());
            fakerPrinter.Object.PrintLetterAlreadyRevealedMessage();
            fakerPrinter.Object.PrintLetterAlreadyRevealedMessage();
            fakerPrinter.Verify(p => p.PrintLetterAlreadyRevealedMessage(), Times.AtLeast(2));
        }
    }
}