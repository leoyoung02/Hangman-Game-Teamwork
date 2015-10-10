namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    internal class Exit : ICommand
    {
        public void Execute(HangmanEngine engine)
        {
            engine.HasCurrentGameEnded = true;
            engine.HaveAllGamesEnded = true;
        }
    }
}
