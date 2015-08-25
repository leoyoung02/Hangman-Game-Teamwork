using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Hangman.Test")]

namespace Hangman.Logic.Utils
{
    using System;
    using Common;
    

    internal class Validator
    {
        internal const int playerNameMaxLenght = 20;
        internal const int comandValidLenght = 1;
        private ConsolePrinter printer = new ConsolePrinter();

        internal Validator()
        {
        }

        internal bool PlayerNameValidator(string inputName)
        {
            if (String.IsNullOrWhiteSpace(inputName))
            {
                this.printer.Write(GlobalMessages.NoNameEntered);
                return false;
            }
            else if (inputName.Length > playerNameMaxLenght)
            {
                this.printer.Write(GlobalMessages.NameTooLong);
                return false;
            }
            else
            {
               return true;
            }
        }

        internal bool InputCommandValidator(string inputCommand)
        {
            if (String.IsNullOrWhiteSpace(inputCommand) || 
                inputCommand.Length != comandValidLenght || 
                !char.IsLetter(inputCommand[0]))
            {
                this.printer.PrintInvalidEntryMessage();
                return false;
            }

            return true;
        }
    }
}
