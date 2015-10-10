namespace Hangman.Logic.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Engines;

    internal class Top : ICommand
    {
        public void Execute(HangmanEngine engine)
        {
            engine.Printer.PrintAllRecords(engine.Scoreboard.TopFiveRecords);
        }
    }
}
