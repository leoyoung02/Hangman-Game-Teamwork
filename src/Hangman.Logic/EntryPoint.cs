namespace Hangman.Logic
{
    using System;

    internal class EntryPoint
    {
        internal static void Main(string[] args)
        {
            bool toExit = false;
            while (!toExit)
            {
                toExit = NewGame.Play();
                Console.WriteLine();
            }
        }
    }
}