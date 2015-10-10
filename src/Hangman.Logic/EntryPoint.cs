namespace Hangman.Logic
{
    using Games;

    internal static class EntryPoint
    {
        internal static void Main()
        {
                var hangmanGameStarter = HangmanGameStarter.Instance;
                hangmanGameStarter.NewGame();
        }
    }
}