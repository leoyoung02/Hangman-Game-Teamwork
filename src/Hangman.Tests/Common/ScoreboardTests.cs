using NUnit.Framework;
using Hangman.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Logic.Tests
{
    [TestFixture()]
    public class ScoreboardTests
    {
        [TestCase(6)]
        [TestCase(27)]
        public void AddNewRecordMoreThanFIvePlayersTest(int entriesCount)
        {
            var scoreboard = Scoreboard.Instance;
            var player = new Player("Chuck Noris", 0);

            for(int i = 0; i < entriesCount; i++)
            {
                scoreboard.AddNewRecord(player);
            }

            int maxEntriesCount = 5;
            int actualEntriesCount = scoreboard.TopFiveRecords.Count;
            Assert.AreEqual(actualEntriesCount, string.Format("Expected entries count: {0}. Actual: {1}", maxEntriesCount, actualEntriesCount));
        }
    }
}