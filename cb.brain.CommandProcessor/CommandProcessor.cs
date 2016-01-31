using AIMLbot;
using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.interfaces;

namespace cb.brain.commandProcessor
{
    public class CommandProcessor
    {
        private readonly ICommandProcessorFactory _commandProcessorFactory;
        private readonly User _myUser;
        private readonly Bot _myBot;

        public CommandProcessor(ICommandProcessorFactory commandProcessorFactory, User myUser, Bot myBot)
        {
            _commandProcessorFactory = commandProcessorFactory;
            _myUser = myUser;
            _myBot = myBot;
        }

        public CommandResponse ProcessCommand(CommandRequest commandRequest)
        {
            var r = new Request(commandRequest.Command, _myUser, _myBot);
            var res = _myBot.Chat(r);
            var whatToDo = res.user.Predicates.grabSetting("whattodo");
            var ret = _myBot.Chat(new Request("DO", _myUser, _myBot));
            var processor = _commandProcessorFactory.GetCommandProcessor(commandRequest);
            return processor.ProcessCommand(commandRequest);
        }
    }
}
