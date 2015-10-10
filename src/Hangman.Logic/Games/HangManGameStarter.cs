namespace Hangman.Logic.Games
{
    using System.Reflection;
    using Contracts;
    using Ninject;
    
    public class HangmanGameStarter
    {
    /// <summary>
    /// A normal game starter object implementing Facade design pattern.
    /// </summary>
    
        private static HangmanGameStarter instance;

        private HangmanGameStarter()
        {
        }

        /// <summary>
        /// Gets a instance of the game <see cref="HangmanGameStarter"/> class.
        /// </summary>
        /// <value>Instance of a game starter.</value>
        public static HangmanGameStarter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HangmanGameStarter();
                }

                return instance;
            }
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        public void NewGame()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var engine = kernel.Get<IGameEngine>();
            engine.Initialize().StartGame();
        }
    }
}
