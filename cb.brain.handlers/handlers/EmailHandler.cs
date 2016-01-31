using System;
using System.Collections.Generic;
using cb.brain.handlers.entities;
using cb.brain.handlers.interfaces;
using OpenPop.Mime;
using OpenPop.Pop3;
using S22.Imap;

namespace cb.brain.handlers.handlers
{
    public class EmailHandler : IEmailHandler
    {
        public GetEmailResponse GetEmail(GetEmailRequest getEmailRequest)
        {
            if (getEmailRequest.EmailProtocol == EmailProtocolEnum.Imap)
                return GetImapEmail(getEmailRequest);
            return GetPopEmail();
        }

        private GetEmailResponse GetImapEmail(GetEmailRequest getEmailRequest)
        {
            using (var client = new ImapClient(getEmailRequest.HostName, getEmailRequest.Port, getEmailRequest.UserName, getEmailRequest.Password, AuthMethod.Login, getEmailRequest.UseSSL))
            {
                var uids = client.Search(SearchCondition.Unseen());
                var messages = client.GetMessages(uids);
                return new GetEmailResponse
                {
                    Messages = messages
                };
            }
        }

        private static GetEmailResponse GetPopEmail()
        {
            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate("cberberian70@gmail.com", "Woq0wy951", AuthenticationMethod.UsernameAndPassword);
            var count = client.GetMessageCount();
            var message = client.GetMessage(count);
            Console.WriteLine(message.Headers.Subject);
            return new GetEmailResponse
            {
            };
        }
    }
}
