using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Hangman.Test")]

namespace Hangman.Logic.Utils
{
    using System;
    using Common;
    using Contracts;

    internal class Validator
    {
        internal const int PlayerNameMaxLenght = 20;
        internal const int ComandValidLenght = 1;
        internal string[] comands = new string[] { "help", "top", "restart", "exit" };
        private readonly IPrinter printer;

        internal Validator(IPrinter printer)
        {
            this.printer = printer;
        }

        internal bool PlayerNameValidator(string inputName)
        {
            if (String.IsNullOrWhiteSpace(inputName))
            {
                this.printer.Write(GlobalMessages.NoNameEntered);
                return false;
            }
            else if (inputName.Length > PlayerNameMaxLenght)
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
            if (Array.IndexOf(comands, inputCommand) == -1 &&
                (String.IsNullOrWhiteSpace(inputCommand) ||
                inputCommand.Length != ComandValidLenght || 
                !char.IsLetter(inputCommand[0])))
            {
                this.printer.PrintInvalidEntryMessage();
                return false;
            }

            return true;
        }
    }
}