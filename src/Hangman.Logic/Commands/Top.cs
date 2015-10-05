using System.Collections.Generic;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
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
