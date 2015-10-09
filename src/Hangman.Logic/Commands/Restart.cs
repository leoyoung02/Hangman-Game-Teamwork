namespace Hangman.Logic.Commands
{
    using Contracts;
    using Engines;

    internal class Restart : ICommand
    {
        private HangmanEngine engine;

        internal Restart(HangmanEngine engine)
        {
            this.Engine = engine;
            this.engine.Initialize().StartGame();
        }

        public HangmanEngine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }
        public void Execute()
        {
            this.engine.HasCurrentGameEnded = true;
        }
    }
}
