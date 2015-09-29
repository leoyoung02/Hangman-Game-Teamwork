namespace Hangman.Logic
{
    using Utils;
    using Contracts;

    internal class HangmanFactory : GameFactory
    {
        public HangmanFactory()
            : base() 
        {
        }

        public override IPlayable CreateGame()
        {
            Game game = new Game(new Engine());
            this.Games.Add(game);

            return game;
        }
    }
}
