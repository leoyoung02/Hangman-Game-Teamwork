namespace Hangman.Logic.Commands
{
    class Top : ICommand
    {
        private Scoreboard scoreboard;

        internal Top(Scoreboard scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        public void Execute()
        {
            scoreboard.PrintAllRecords();
        }
    }
}
