using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.interfaces;
using Insteon.Network;

namespace cb.brain.commandProcessor.processors
{
    public class InsteonCommandProcessor : ICommandProcessor
    {
        public CommandResponse ProcessCommand(CommandRequest commandRequest)
        {
            var network = new InsteonNetwork();
            var connection = new InsteonConnection(InsteonConnectionType.Net, "");
            network.Connect(connection);
            
            
            return new CommandResponse();

        }
    }
}