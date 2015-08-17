namespace Hangman.Logic
{
    using System;

    internal class WordInitializer
    {
        private string word;
        private char[] displayableWord;

        internal WordInitializer()
        {
            this.Word = this.word;
            this.DisplayableWord = this.displayableWord;
        }

        internal string Word
        {
            get { return this.word; }
            private set { this.word = this.SelectRandomWord(); }
        }

        internal char[] DisplayableWord
        {
            get { return this.displayableWord; }
            private set { this.displayableWord = this.GenerateEmptyWordOfUnderscores(this.Word.Length); }
        }

        private string SelectRandomWord()
        {
            Array words = Enum.GetValues(typeof(Words.Store));
            Words.Store randomWord = (Words.Store)words.GetValue(new Random().Next(words.Length));
            return randomWord.ToString().ToLower(); 
        }

        private char[] GenerateEmptyWordOfUnderscores(int wordLength)
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