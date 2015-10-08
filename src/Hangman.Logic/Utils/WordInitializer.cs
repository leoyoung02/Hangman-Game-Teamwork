namespace Hangman.Logic.Utils
{
    using System;

    public class WordInitializer
    {
        private string word;
        private char[] wordOfUnderscores;

        public WordInitializer()
        {
            this.Word = this.word;
            this.GuessedWordLetters = this.wordOfUnderscores;
        }

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