namespace Hangman.Logic.Factories
{
    using System.Collections.Generic;
    using Commands;
    using Contracts;
    using Engines;
    using Games;

    public class CommandFactory
    {
        /// <summary>
        /// Factory method for creating commands
        /// </summary>
        /// <param name="inputCommand">User input string</param>
        /// <returns>ICommand object</returns>
        public ICommand CreateCommand(string inputCommand)
        {
            ICommand command;
            // TODO: throw invalid command exception if not a valid command or length > 1
            switch (inputCommand)
            {
                case "help":
                    command = new Help();
                    break;
                case "top":
                    command = new Top();
                    break;
                case "restart":
                    command = new Restart();
                    break;
                case "exit":
                    command = new Exit();
                    break;
                default:
                    command = new LetterGuess(inputCommand);
                    break;
            }

            return command;
        }
    }
}
