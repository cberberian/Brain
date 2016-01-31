using cb.brain.commandProcessor.entities;

namespace cb.brain.commandProcessor.interfaces
{
    public interface ICommandProcessor
    {
        CommandResponse ProcessCommand(CommandRequest commandRequest);
    }
}