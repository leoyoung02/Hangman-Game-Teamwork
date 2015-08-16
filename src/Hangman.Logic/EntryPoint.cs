namespace Hangman.Logic
{
    using System;

    internal static class EntryPoint
    {
        internal static void Main(string[] args)
        {
            bool isExitTriggered = false;
            while (!isExitTriggered)
            {
                var game = new Game();
                isExitTriggered = game.Play();
                Console.WriteLine();
            }
        }
    }
}