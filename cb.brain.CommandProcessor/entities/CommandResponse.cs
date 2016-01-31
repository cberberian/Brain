using System.Collections;
using System.Collections.Generic;

namespace cb.brain.commandProcessor.entities
{
    public class CommandResponse
    {
        public Queue<CommandResult> Queue { get; set; }
    }

    public class CommandResult
    {
        public CommandResultTypeEnum ResultType { get; set; }
        public string Content { get; set; }
        public int Pause { get; set; }
        public bool WaitInput { get; set; }
    }

    public enum CommandResultTypeEnum
    {
        Text,
        Bot
    }
}