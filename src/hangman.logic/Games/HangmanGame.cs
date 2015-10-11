namespace Hangman.Logic.Games
{
    using Utils;

    public class HangmanGame : Game
    {
        private WordInitializer wordInitializer;
        public HangmanGame(WordInitializer wordInitializer)
        {
            this.WordInitializer = wordInitializer;
        }

        public WordInitializer WordInitializer { get; set; }    
    }
}