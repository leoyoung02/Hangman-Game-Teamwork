namespace Hangman.Logic
{
    /// <summary>
    /// Player class. Stores player name and score.
    /// </summary>
    public class Player
    {
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
        public string PlayerName { get; set; }

        /// <summary>
        /// Public property for player score
        /// </summary>
        public int Score { get; set; }
    }
}