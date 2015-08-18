namespace Hangman.Logic.Commands
{
    internal class Top : ICommand
    {
        private Scoreboard scoreboard;

        internal Top(Scoreboard scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        public void Execute()
        {
            this.scoreboard.PrintAllRecords();
        }
    }
}
