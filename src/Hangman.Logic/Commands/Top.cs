namespace Hangman.Logic.Commands
{
    using System.Collections.Generic;
    using Contracts;
    internal class Top : ICommand
    {
        private IPrinter printer;
        private List<Player> scores;

        internal Top(IPrinter printer, List<Player> scores)
        {
            this.printer = printer;
            this.scores = scores;
        }

        public void Execute()
        {
            this.printer.PrintAllRecords(scores);
        }
    }
}
