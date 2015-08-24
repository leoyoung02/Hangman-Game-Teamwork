namespace Hangman.Logic
{
    using System;

    public class Player
    {
        private string playerName;
        private int score;

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
                this.score = value;
            }
        }
        
    }
}
                                                         