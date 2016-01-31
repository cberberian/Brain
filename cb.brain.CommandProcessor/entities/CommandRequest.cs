namespace cb.brain.commandProcessor.entities
{
    public class CommandRequest
    {
        public CommandCategoryEnum Category { get; set; }
        public string Command { get; set; }
    }

    public enum CommandCategoryEnum
    {
        Email
    }
}