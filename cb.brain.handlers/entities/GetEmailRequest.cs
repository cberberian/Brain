using cb.brain.handlers.handlers;

namespace cb.brain.handlers
{
    public class GetEmailRequest
    {
        public bool UseSSL;
        public EmailProtocolEnum EmailProtocol { get; set; }
        public string HostName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int Port { get; set; }
    }
}