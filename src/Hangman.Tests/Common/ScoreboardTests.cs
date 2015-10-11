namespace Hangman.Logic.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ScoreboardTests
    {
        [TestCase(6)]
        [TestCase(27)]
        public void AddNewRecordMoreThanFIvePlayersTest(int entriesCount)
        {
            var scoreboard = Scoreboard.Instance;
            var player = new Player("Chuck Noris", 0);

            for (int i = 0; i < entriesCount; i++)
            {
                scoreboard.AddNewRecord(player);
            }

            int maxEntriesCount = Scoreboard.MaxRecords;
            int actualEntriesCount = scoreboard.TopFiveRecords.Count;
            Assert.AreEqual(maxEntriesCount, actualEntriesCount, string.Format("Expected entries count: {0}. Actual: {1}", maxEntriesCount, actualEntriesCount));
        }
    }
}