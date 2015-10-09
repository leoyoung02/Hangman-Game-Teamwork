namespace Hangman.Logic.Contracts
{
    using System;
    public interface IReader
    {
        string ReadLine();

        ConsoleKeyInfo ReadKey();
    }
}
