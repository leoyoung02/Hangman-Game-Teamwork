namespace Hangman.Logic
{
    using Ninject.Modules;
    using Contracts;
    using Commands;
    using Engines;

    public class Ninjector : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommand>().To<Exit>();
            Bind<ICommand>().To<Help>();
            Bind<ICommand>().To<LetterGuess>();
            Bind<ICommand>().To<Restart>();
            Bind<ICommand>().To<Top>();
            Bind<IGameEngine>().To<HangmanEngine>();
            Bind<IPrinter>().To<ConsolePrinter>();
            Bind<IReader>().To<ConsoleReader>();
        }
    }
}
