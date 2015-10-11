namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    /// <summary>
    /// Exit command class
    /// </summary>
    internal class Exit : ICommand
    {
        /// <summary>
        /// Execute command. Ends the game and closes the program by setting HasCurrentGameEnded and HaveAllGamesEnded to true and braking all the loops.
        /// </summary>
        /// <param name="engine">The game engine</param>
        public void Execute(HangmanEngine engine)
        {
            engine.HasCurrentGameEnded = true;
            engine.HaveAllGamesEnded = true;
        }
    }
}
