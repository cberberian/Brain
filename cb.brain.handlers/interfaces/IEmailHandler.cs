using cb.brain.handlers.entities;

namespace cb.brain.handlers.interfaces
{
    public interface IEmailHandler
    {
        GetEmailResponse GetEmail(GetEmailRequest getEmailRequest);
    }
}