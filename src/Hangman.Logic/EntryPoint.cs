namespace Hangman.Logic
{
    using System;

    internal class EntryPoint
    {
        internal static void Main(string[] args)
        {
            bool gamesAreOver = false;
            while (!gamesAreOver)
            {
                gamesAreOver = NewGame.Play();
                Console.WriteLine();
            }
        }
    }
}