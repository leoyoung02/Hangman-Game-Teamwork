namespace Hangman.Logic
{
    using System;
    using Contracts;
    using Utils;

    internal class Player
    {
        private readonly Validator validator;
        private string playerName;
        private int score;

        public Player(string playerName, int score, IPrinter printer)
        {
            this.validator = new Validator(printer);
            this.PlayerName = playerName;
            this.Score = score;
        }

        public string PlayerName
        {
            get 
            {
                return this.playerName; 
            }

            set 
            {
                if (!this.validator.PlayerNameValidator(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.playerName = value; 
            }
        }

        public int Score
        {
            get 
            {
                return this.score;
            }

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score must be non negative!");
                }

                this.score = value;
            }
        }
    }
}                                                         