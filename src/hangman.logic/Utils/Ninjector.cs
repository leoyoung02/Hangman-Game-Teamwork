namespace Hangman.Logic
{
    using Contracts;
    using Engines;
    using Ninject.Modules;

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