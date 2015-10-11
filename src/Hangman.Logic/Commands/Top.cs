namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    /// <summary>
    /// Display scoreboard command class
    /// </summary>
    internal class Top : ICommand
    {
        /// <summary>
        /// Execute command. Trigures printing of the top results from scoreboard
        /// </summary>
        /// <param name="engine">The game engine</param>
        public void Execute(HangmanEngine engine)
        {
            engine.Printer.PrintAllRecords(engine.Scoreboard.TopFiveRecords);
        }
    }
}
