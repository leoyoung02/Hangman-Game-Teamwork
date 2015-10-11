namespace Hangman.Tests
{
    using Logic.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ConsoleReaderTests
    {
        [TestMethod]
        public void ConsoleReadKeyMethodIsCalledAtLeastTwice()
        {
            var fakerReader = new Mock<IReader>();
            fakerReader.Setup(r => r.ReadKey());
            fakerReader.Object.ReadKey();
            fakerReader.Object.ReadKey();
            fakerReader.Verify(r => r.ReadKey(), Times.AtLeast(2));
        }

        [TestMethod]
        public void ConsoleReadLineMethodIsCalledAtLeastTwice()
        {
            var fakerReader = new Mock<IReader>();
            fakerReader.Setup(r => r.ReadLine());
            fakerReader.Object.ReadLine();
            fakerReader.Object.ReadLine();
            fakerReader.Verify(r => r.ReadLine(), Times.AtLeast(2));
        }
    }
}
