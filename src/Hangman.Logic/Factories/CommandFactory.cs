namespace Hangman.Logic.Factories
{
    using System.Collections.Generic;
    using Commands;
    using Contracts;
    using Engines;
    using Games;

    public class CommandFactory
    {
        public ICommand CreateCommand(string inputCommand, HangmanEngine gameEngine)
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
