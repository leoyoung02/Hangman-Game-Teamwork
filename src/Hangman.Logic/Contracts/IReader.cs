namespace Hangman.Logic.Contracts
{
    using System;
    internal interface IReader
    {
        string ReadLine();

        ConsoleKeyInfo ReadKey();
    }
}
