using System.Collections.Generic;
using System.Net.Mail;

namespace cb.brain.handlers.entities
{
    public class GetEmailResponse
    {
        public IEnumerable<MailMessage> Messages { get; set; }
    }
}