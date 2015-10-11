namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    /// <summary>
    /// Restart command class
    /// </summary>
    internal class Restart : ICommand
    {
        /// <summary>
        /// Execute command. Restarts the game with a new secret word. 
        /// </summary>
        /// <param name="engine"></param>
        public void Execute(HangmanEngine engine)
        {
            engine.Initialize().StartGame();
        }
    }
}
