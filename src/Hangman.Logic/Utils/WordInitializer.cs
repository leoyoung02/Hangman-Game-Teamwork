namespace Hangman.Logic.Utils
{
    using System;

    /// <summary>
    ///  Class that holds information about the word the user is guessing.
    ///  Also generates random word for the user to guess.
    /// </summary>
    public class WordInitializer
    {
        private string word;
        private char[] wordOfUnderscores;

        public WordInitializer()
        {
            this.Word = this.word;
            this.GuessedWordLetters = this.wordOfUnderscores;
        }

        /// <summary>
        ///  Property that holds the word to guess.
        /// </summary>
        public string Word
        {
            get
            {
                return this.word;
            }

            private set
            {
                this.word = this.SelectRandomWord();
            }
        }

        /// <summary>
        ///     Array that holds chars that are guessed by the user.
        /// </summary>
        public char[] GuessedWordLetters
        {
            get 
            {
                return this.wordOfUnderscores;
            }

            set 
            {
                this.wordOfUnderscores = this.GenerateWordOfUnderscores(this.Word.Length);
            }
        }

        private string SelectRandomWord()
        {
            var words = Enum.GetValues(typeof(Words));
            var random = new Random();
            Words randomWord = (Words)words.GetValue(random.Next(words.Length));
            return randomWord.ToString().ToLower();
        }

        private char[] GenerateWordOfUnderscores(int wordLength)
        {
            char[] wordOfUnderscores = new char[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                wordOfUnderscores[i] = '_';
            }

            return wordOfUnderscores;
        }
    }
}