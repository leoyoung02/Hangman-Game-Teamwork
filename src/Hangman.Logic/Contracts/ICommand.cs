namespace Hangman.Logic.Contracts
{
    using Hangman.Logic.Engines;

    public interface ICommand
    {
        void Execute(HangmanEngine engine);
    }
}
