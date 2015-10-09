namespace Hangman.Logic.Games
{
    using Utils;

    public class HangmanGame : Game
    {
        private WordInitializer wordInitializer;
        public HangmanGame(WordInitializer wordInitializer)
            :base()
        {
            this.WordInitializer = wordInitializer;
        }

        public WordInitializer WordInitializer
        {
            get
            {
                return this.wordInitializer;
            }

            set
            {
                this.wordInitializer = value;
            }
        }
    
    }
}