namespace Hangman.Logic.Factories
{
    using Commands;
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class CommandFactory
    {
        private readonly Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();

        /// <summary>
        /// Factory method for creating commands
        /// </summary>
        /// <param name="inputCommand">User input string</param>
        /// <returns>ICommand object</returns>
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
                        if (inputCommand.Length != 1 || string.IsNullOrWhiteSpace(inputCommand))
                        {
                            throw new ArgumentException(GlobalMessages.IncorrectGuessOrCommand);
                        }

                        command = new LetterGuess(inputCommand);
                        break;
                }

                return command;
            }
        }
    }
}