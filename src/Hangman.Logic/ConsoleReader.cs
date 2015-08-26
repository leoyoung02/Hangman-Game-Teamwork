using Hangman.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Logic
{
    class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
