namespace Hangman.Tests
{
    using Logic;
    using Logic.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class ConsolePrinterTests
    {
        [TestMethod]
        public void PrintWelcomeMessageIsCalledAtLeastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintWelcomeMessage());
            fakerPrinter.Object.PrintWelcomeMessage();
            fakerPrinter.Object.PrintWelcomeMessage();
            fakerPrinter.Verify(p => p.PrintWelcomeMessage(), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintWordToGuessIsCalledAtLeastTwice()
        {
            char[] wordToGuess = "tralala".ToCharArray();
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintWordToGuess(wordToGuess));
            fakerPrinter.Object.PrintWordToGuess(wordToGuess);
            fakerPrinter.Object.PrintWordToGuess(wordToGuess);
            fakerPrinter.Verify(p => p.PrintWordToGuess(wordToGuess), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintInvalidEntryMessageIsCalledAtLeastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            fakerPrinter.Setup(p => p.PrintInvalidEntryMessage());
            fakerPrinter.Object.PrintInvalidEntryMessage();
            fakerPrinter.Object.PrintInvalidEntryMessage();
            fakerPrinter.Verify(p => p.PrintInvalidEntryMessage(), Times.AtLeast(2));
        }

        [TestMethod]
        public void PrintWinMessageIsCalledAtLeastTwice()
        {
            var fakerPrinter = new Mock<IPrinter>();
            var scoreboard = Scoreboard.Instance;
            char[] wordToGuess = "tralala".ToCharArray();
            fakerPrinter.Setup(p => p.PrintWinMessage(0,true, scoreboard, wordToGuess));
            fakerPrinter.Object.PrintWinMessage(0, true, scoreboard, wordToGuess);
            fakerPrinter.Object.PrintWinMessage(0, true, scoreboard, wordToGuess);
            fakerPrinter.Verify(p => p.PrintWinMessage(0, true, scoreboard, wordToGuess), Times.AtLeast(2));
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