namespace Hangman.Logic.Utils
{
    using System;
    using Common;

    internal class Validator
    {
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
            else if (inputName.Length > 20)
            {
                this.printer.Write(GlobalMessages.NameTooLong);
                return false;
            }
            else
            {
               return true;
            }
        }

        internal bool InputCommantValidator(string inputCommand)
        {
            if (String.IsNullOrWhiteSpace(inputCommand) || inputCommand.Length != 1 || !char.IsLetter(inputCommand[0]))
            {
                this.printer.PrintInvalidEntryMessage();
                return false;
            }

            return true;
        }
    }
}
