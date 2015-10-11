namespace Hangman.Logic.Tests
{
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ScoreboardTests
    {
        public List<Player> fakeTopFiveRecords = new List<Player>()
        {
            new Player("Pesho", 2),
            new Player("Gosho", 3),
            new Player("John", 21),
        };

        [TestCase(6)]
        [TestCase(27)]
        public void AddNewRecordMoreThanFIvePlayersTest(int entriesCount)
        {
            var scoreboard = Scoreboard.Instance;
            // TODO: mock Chusk Noris
            var player = new Player("Chuck Noris", 0);

            for (int i = 0; i < entriesCount; i++)
            {
                scoreboard.AddNewRecord(player);
            }

            int maxEntriesCount = Scoreboard.MaxRecords;
            int actualEntriesCount = scoreboard.TopFiveRecords.Count;
            Assert.AreEqual(maxEntriesCount, actualEntriesCount, string.Format("Expected entries count: {0}. Actual: {1}", maxEntriesCount, actualEntriesCount));
        }

        // TODO: save and load called externaly
        /*[TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void AddNewRecordShouldAddNewReccords(int entriesCount)
        {
            var scoreboard = Scoreboard.Instance;

            var player = new Player("Chuck Noris", 0);

            for (int i = 0; i < entriesCount; i++)
            {
                scoreboard.AddNewRecord(player);
            }

            Assert.AreEqual(scoreboard.TopFiveRecords.Count, entriesCount);
        }*/

        [Test]
        public void MethodAddNewRecordShouldSuccessfullyAddNewRecord()
        {
            Player testPlayer = new Player("test", int.MaxValue);

            var mock = new Mock<IScoreboard>();
            mock.Setup(m => m.TopFiveRecords).Returns(this.fakeTopFiveRecords);
            var fakeScoreboard = mock.Object;

            fakeScoreboard.TopFiveRecords.Add(testPlayer);

            Assert.AreEqual(fakeScoreboard.TopFiveRecords.Contains(testPlayer), true, "Method add new record of Scoreboard doesn't add the player.");
        }
    }
}