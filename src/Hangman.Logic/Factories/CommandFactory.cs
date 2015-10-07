namespace Hangman.Logic.Factories
{
    using System.Collections.Generic;
    using Commands;
    using Contracts;

    internal class CommandFactory
    {
        public ICommand CreateCommand(string inputCommand, HangmanEngine gameEngine, List<Player> scores)
        {
            ICommand command;

            switch (inputCommand)
            {
                case "help":
                    command = new Help(gameEngine);
                    break;
                case "top":
                    command = new Top(gameEngine.Printer, scores);
                    break;
                case "restart":
                    command = new Restart(gameEngine);
                    break;
                case "exit":
                    command = new Exit(gameEngine);
                    break;
                default:
                    command = new LetterGuess(inputCommand, gameEngine);
                    break;
            }

            return command;
        }
    }
}
