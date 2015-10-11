using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Logic.Contracts
{
    public interface ICommandContext
    {
        string GlobalMessage { get; set; }

        IPrinter Printer { get; set; }

        IReader Reader { get; set; }

        Game Game { get; set; }

        Scoreboard Scoreboard { get; set; } 



    }
}
