namespace Hangman.Logic
{
    using System;
    using Utils;

    public class Player
    {
        private string playerName;
        private int score;
        private readonly Validator validator = new Validator(new ConsolePrinter());

        public Player(string playerName, int score)
        {
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