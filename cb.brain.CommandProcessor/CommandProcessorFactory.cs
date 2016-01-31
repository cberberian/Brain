using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.interfaces;
using cb.brain.commandProcessor.processors;

namespace cb.brain.commandProcessor
{
    public class CommandProcessorFactory : ICommandProcessorFactory
    {
        private readonly IEmailCommandProcessor _emailCommandProcessor;

        public CommandProcessorFactory(IEmailCommandProcessor emailCommandProcessor)
        {
            _emailCommandProcessor = emailCommandProcessor;
        }

        public ICommandProcessor GetCommandProcessor(CommandRequest commandRequest)
        {
            switch (commandRequest.Category)
            {
                case CommandCategoryEnum.Email:
                    return _emailCommandProcessor;
            }
            return new InsteonCommandProcessor();

        }
    }
}