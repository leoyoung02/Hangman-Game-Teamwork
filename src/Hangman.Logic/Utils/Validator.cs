namespace Hangman.Logic.Utils
{
    using System;
    using Common;
    using Contracts;

    public class Validator
    {
        private const int PlayerNameMaxLenght = 20;
        private const int ComandValidLenght = 1;
        private readonly IPrinter printer;

        private string[] comands = new string[] { "help", "top", "restart", "exit" };

        internal Validator(IPrinter printer)
        {
            this.printer = printer;
        }

        internal bool PlayerNameValidator(string inputName)
        {
            if (string.IsNullOrWhiteSpace(inputName))
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
            if (Array.IndexOf(this.comands, inputCommand) == -1 &&
                (string.IsNullOrWhiteSpace(inputCommand) ||
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