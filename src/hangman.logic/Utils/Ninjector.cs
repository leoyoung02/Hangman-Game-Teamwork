namespace Hangman.Logic
{
    using Ninject.Modules;
    using Contracts;
    using Engines;

    public class Ninjector : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameEngine>().To<HangmanEngine>();
            Bind<IPrinter>().To<ConsolePrinter>();
            Bind<IReader>().To<ConsoleReader>();
        }
    }
}