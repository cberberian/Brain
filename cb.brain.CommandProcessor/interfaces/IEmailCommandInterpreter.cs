using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.enums;
using cb.brain.handlers.entities;

namespace cb.brain.commandProcessor.interfaces
{
    public interface IEmailCommandInterpreter
    {
        EmailCommandInterpetation InterpretCommand(CommandRequest commandRequest);
        CommandResponse GetCommandResponse(GetEmailResponse emailResponse);
    }
}