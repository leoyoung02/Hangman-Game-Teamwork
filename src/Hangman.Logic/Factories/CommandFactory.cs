namespace Hangman.Logic.Factories
{
    using System.Collections.Generic;
    using Commands;
    using Contracts;

    public class CommandFactory
    {
        /// <summary>
        /// Factory method for creating commands
        /// </summary>
        /// <param name="inputCommand">User input string</param>
        /// <returns>ICommand object</returns>
        private readonly Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();

        public ICommand CreateCommand(string inputCommand)
        {
            inputCommand = inputCommand.ToLower();
            if (this.commandDictionary.ContainsKey(inputCommand))
            {
                return this.commandDictionary[inputCommand];
            }
            else
            {
                ICommand command;

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
}