namespace Hangman.Logic
{
    using System;
    using Contracts;

    /// <summary>
    /// Class for reading user input from the console
    /// </summary>
    internal class ConsoleReader : IReader
    {
        /// <summary>
        /// Method for readng text input from the console
        /// </summary>
        /// <returns>User command</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Method for reading keypress info from the console
        /// </summary>
        /// <returns>User command</returns>
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
