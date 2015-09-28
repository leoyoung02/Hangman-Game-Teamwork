using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Logic.Contracts
{
    interface IEngine
    {
        ConsolePrinter Printer { get; set; }

        bool HasCurrentGameEnded { get; set; }

        char[] WordOfUnderscores { get; set; }

        void GetUserInput();

        bool CheckIfGameIsWon();

        bool HaveAllGamesEnded { get; set; }
    }
}
