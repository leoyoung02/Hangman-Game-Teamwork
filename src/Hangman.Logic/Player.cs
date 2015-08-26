namespace Hangman.Logic
{
    using Utils;
    using System;

    public class Player
    {
        private string playerName;
        private int score;
        private readonly Validator validator;

        public Player(string playerName, int score)
        {
            this.validator = new Validator();
            this.PlayerName = playerName;
            this.Score = score;
        }

        public string PlayerName
        {
            get 
            {
                return playerName; 
            }

            set 
            {
                if (!validator.PlayerNameValidator(value))
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
                return score;
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