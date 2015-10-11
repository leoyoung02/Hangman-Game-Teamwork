namespace Hangman.Logic.Utils
{
    using System;

    /// <summary>
    /// User input rules
    /// </summary>
    public class Validator
    {
        private const int PlayerNameMaxLenght = 20;
        private const int ComandValidLenght = 1;

        // TODO: duplicate command names
        private readonly string[] comands = new string[] { "help", "top", "restart", "exit" };

        /// <summary>
        /// Player name length validation method
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <returns>Is name length valid</returns>
        internal bool PlayerNameIsTooLong(string playerName)
        {
            if (playerName.Length > PlayerNameMaxLenght)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Player name not empty validation method
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <returns>Player name is not null or whitespace</returns>
        internal bool PlayerNameIsNullOrWhiteSpace(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Command validation
        /// </summary>
        /// <param name="inputCommand">User input string</param>
        /// <returns>Is string a valid command or a character</returns>
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