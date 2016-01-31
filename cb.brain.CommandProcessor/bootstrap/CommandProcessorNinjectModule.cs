using cb.brain.commandProcessor.interfaces;
using cb.brain.commandProcessor.processors;
using Ninject.Modules;

namespace cb.brain.commandProcessor.bootstrap
{
    public class CommandProcessorNinjectModule : NinjectModule
    {
        public override void Load()
        {

            Bind<ICommandProcessorFactory>().To<CommandProcessorFactory>();
            Bind<IEmailCommandInterpreter>().To<EmailCommandInterpreter>();
            Bind<ICommandProcessorFactory>().To<CommandProcessorFactory>();

        }
    }
}