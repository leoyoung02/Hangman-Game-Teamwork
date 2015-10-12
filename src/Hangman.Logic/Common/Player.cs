namespace Hangman.Logic
{
    using System;
    using Common;

    /// <summary>
    /// Player class. Stores player name and score.
    /// </summary>
    public class Player
    {
        private string playerName;

        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="playerName">Non empty name</param>
        /// <param name="score">The mistakes count. The lower the better</param>
        public Player(string playerName, uint score)
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
                return this.playerName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(GlobalMessages.PlayerNoNameEntered);
                }

                this.playerName = value;
            }
        }

        /// <summary>
        /// Public property for player score
        /// </summary>
        public uint Score { get; set; }
    }
}