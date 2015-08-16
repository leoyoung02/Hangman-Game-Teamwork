using System;

namespace Hangman.Logic
{
    internal class EntryPoint
    {
        internal static void Main(string[] args)
        {
            bool gamesAreOver = false;
            while (!gamesAreOver)
            {
                gamesAreOver = Hangman.PlayOneGame();
                Console.WriteLine();
            }
        }
    }
}