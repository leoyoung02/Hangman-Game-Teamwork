using System;

namespace Hangman.Logic.Contracts
{
    internal interface IReader
    {
        string ReadLine();

        ConsoleKeyInfo ReadKey();
    }
}
