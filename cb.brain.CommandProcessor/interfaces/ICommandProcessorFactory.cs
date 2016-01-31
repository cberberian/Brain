using cb.brain.commandProcessor.entities;

namespace cb.brain.commandProcessor.interfaces
{
    public interface ICommandProcessorFactory
    {
        ICommandProcessor GetCommandProcessor(CommandRequest commandRequest);
    }
}