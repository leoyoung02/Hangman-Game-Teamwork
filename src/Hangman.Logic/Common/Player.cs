namespace Hangman.Logic
{
    /// <summary>
    /// Player class. Stores player name and score.
    /// </summary>
    public class Player
    {
        private string playerName;
        private int score;

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="playerName">Non empty name</param>
        /// <param name="score">The mistakes count. The lower the better</param>
        public Player(string playerName, int score)
        {
            this.PlayerName = playerName;
            this.Score = score;
        }

        /// <summary>
        /// Public property for player name
        /// </summary>
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

        /// <summary>
        /// Public property for player score
        /// </summary>
        public int Score
        {
            get 
            {
                return score;
            }

            private set 
            {
                this.score = value;
            }
        }
    }
}                                                         