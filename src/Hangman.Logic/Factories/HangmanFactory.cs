namespace Hangman.Logic
{
    using Contracts;
    using Utils;

    internal class HangmanFactory : GameFactory
    {
        public HangmanFactory()
            : base() 
        {
        }

        public override IPlayable CreateGame()
        {
            Game game = new Game(new HangmanEngine());
            this.Games.Add(game);

            return game;
        }
    }
}
