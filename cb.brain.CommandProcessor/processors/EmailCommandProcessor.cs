using System.Linq;
using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.enums;
using cb.brain.commandProcessor.interfaces;
using cb.brain.handlers;
using cb.brain.handlers.entities;
using cb.brain.handlers.handlers;
using cb.brain.handlers.interfaces;

namespace cb.brain.commandProcessor.processors
{
    public class EmailCommandProcessor : IEmailCommandProcessor
    {
        private readonly IEmailHandler _emailHandler;

        public EmailCommandProcessor(IEmailHandler emailHandler)
        {
            _emailHandler = emailHandler;
        }

        public CommandResponse ProcessCommand(CommandRequest commandRequest)
        {

            if (commandRequest.Command == "GetEmails")
            {
                var getEmailRequest = new GetEmailRequest
                {
                    EmailProtocol = EmailProtocolEnum.Imap,
                    HostName = "pop.gmail.com",
                    UserName = "cberberian70@gmail.com",
                    Password = "Woq0wy951"
                };
                var emailResponse = _emailHandler.GetEmail(getEmailRequest);
                return GetCommandResponse(emailResponse);
            }
            return new CommandResponse();
        }

        private static CommandResponse GetCommandResponse(GetEmailResponse emailResponse)
        {
            var commandResponse = new CommandResponse();
            commandResponse.Queue.Enqueue(new CommandResult
            {
                Content = $"You have {emailResponse.Messages.Count()} Emails",

            });
            return commandResponse;
        }
    }
}