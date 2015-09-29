namespace Hangman.Logic
{
    using System;

    internal static class EntryPoint
    {
        internal static void Main()
        {
            bool isExitTriggered = false;
            var hangmanFactory = new HangmanFactory();

            while (!isExitTriggered)
            {
                var game = hangmanFactory.CreateGame();
                isExitTriggered = game.Play();
                Console.WriteLine();
            }
        }
    }
}