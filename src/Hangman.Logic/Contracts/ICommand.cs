namespace Hangman.Logic.Contracts
{
    using Engines;

    /// <summary>
    /// Command interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="engine">Object to execute the command on</param>
        void Execute(HangmanEngine engine);
    }
}
