using System.Collections.Generic;

namespace Hangman.Logic.Commands
{
    internal class Top : ICommand
    {
        private ConsolePrinter printer;
        private List<Player> scores;

        internal Top(ConsolePrinter printer, List<Player> scores)
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
