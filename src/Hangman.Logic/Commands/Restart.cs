namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    internal class Restart : ICommand
    {
        public void Execute(HangmanEngine engine)
        {
            engine.HasCurrentGameEnded = true;
        }
    }
}
