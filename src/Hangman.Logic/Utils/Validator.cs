namespace Hangman.Logic.Utils
{
    using System;
    using Common;
    using Contracts;

    public class Validator
    {
        private const int PlayerNameMaxLenght = 20;
        private const int ComandValidLenght = 1;

        private string[] comands = new string[] { "help", "top", "restart", "exit" };

        public Validator()
        {
        }

        internal bool PlayerNameIsTooLong(string playerName)
        {
            if (playerName.Length > PlayerNameMaxLenght)
            {
                return true;
            }

            return false;
        }

        internal bool PlayerNameIsNullOrWhiteSpace(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                return true;
            }

            return false;
        }

        internal bool InputCommandIsValid(string inputCommand)
        {
            if (Array.IndexOf(this.comands, inputCommand) == -1 &&
                (string.IsNullOrWhiteSpace(inputCommand) ||
                inputCommand.Length != ComandValidLenght ||
                !char.IsLetter(inputCommand[0])))
            {
                return false;
            }

            return true;
        }
    }
}