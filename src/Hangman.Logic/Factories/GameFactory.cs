namespace Hangman.Logic.Utils
{
    using System.Collections.Generic;
    using Contracts;

    internal abstract class GameFactory
    {
        private List<IPlayable> _games;

        protected GameFactory()
        {
            this._games = new List<IPlayable>();
        }
        
        public List<IPlayable> Games {
            get
            {
                return this._games;
            }

            private set
            {
                this._games = value;
            }        
       }
        public abstract IPlayable CreateGame();     
    }
}
