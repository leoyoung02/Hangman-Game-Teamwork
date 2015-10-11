namespace Hangman.Logic.Games
{
    using Utils;

    public class HangmanGame : Game
    {
        public HangmanGame(WordInitializer wordInitializer)
        {
            this.WordInitializer = wordInitializer;
        }

        public WordInitializer WordInitializer { get; set; }    
    }
}