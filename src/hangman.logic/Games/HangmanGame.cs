namespace Hangman.Logic.Games
{
    using Utils;

    /// <summary>
    ///  Main class that holds the logic about the word to be guessed.
    /// </summary>
    public class HangmanGame : Game
    {
        public HangmanGame(WordInitializer wordInitializer)
        {
            this.WordInitializer = wordInitializer;
        }

        /// <summary>
        ///  Instance of the WordInitializer class that generates random word.
        /// </summary>
        public WordInitializer WordInitializer { get; set; }    
    }
}