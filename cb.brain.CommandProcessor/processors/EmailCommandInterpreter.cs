using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.enums;
using cb.brain.commandProcessor.interfaces;
using cb.brain.handlers.entities;

namespace cb.brain.commandProcessor.processors
{
    public class EmailCommandInterpreter : IEmailCommandInterpreter
    {
        public EmailCommandInterpetation InterpretCommand(CommandRequest commandRequest)
        {
            return new EmailCommandInterpetation();
        }

        public CommandResponse GetCommandResponse(GetEmailResponse emailResponse)
        {
            return new CommandResponse();
        }
    }
}