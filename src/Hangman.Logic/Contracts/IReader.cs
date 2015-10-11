namespace Hangman.Logic.Contracts
{
    using System;

    /// <summary>
    /// Abstraction for reading input from thhe UI
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Method for reading the text input
        /// </summary>
        /// <returns>Uset text command</returns>
        string ReadLine();

        /// <summary>
        /// Method for reading keypress info
        /// </summary>
        /// <returns>Keypress info</returns>
        ConsoleKeyInfo ReadKey();
    }
}