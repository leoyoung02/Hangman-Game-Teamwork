namespace Hangman.Logic.Contracts
{
    using System;

    /// <summary>
    /// Abstraction for reading input from thhe UI
    /// </summary>
    public interface IReader
    {
        string ReadLine();

        ConsoleKeyInfo ReadKey();
    }
}
