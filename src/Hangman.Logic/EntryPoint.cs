namespace Hangman.Logic
{
    using System;
    using Contracts;
    using Engines;
    using Factories;
    using Games;
    using Utils;

    internal static class EntryPoint
    {
        internal static void Main()
        {
            // TODO: remove the printer from validator 
            bool isExitTriggered = false;
            IGameEngine hangmanEngine = new HangmanEngine(new ConsolePrinter(), new ConsoleReader(), new CommandFactory(), new Validator(new ConsolePrinter()), new HangmanGame(new WordInitializer()));

            while (!isExitTriggered)
            {
                isExitTriggered = hangmanEngine.Initialize().StartGame();
                Console.WriteLine();
            }
        }
    }
}