namespace Hangman.Logic
{
    class ShowScoreboardCommand : ICommand
    {
        private Scoreboard scoreboard;

        internal ShowScoreboardCommand(Scoreboard scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        public void Execute()
        {
            scoreboard.PrintAllRecords();
        }
    }
}
