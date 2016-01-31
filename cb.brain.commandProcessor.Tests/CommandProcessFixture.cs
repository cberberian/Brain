using System.Speech.Synthesis;
using AIMLbot;
using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.interfaces;
using cb.brain.handlers;
using cb.brain.handlers.handlers;
using Moq;
using NUnit.Framework;

namespace cb.brain.commandProcessor.Tests
{
    [TestFixture]
    public class CommandProcessFixture
    {
        private Bot _myBot;
        private User _myUser;
        private SpeechSynthesizer _synth;

        [Test]
        public void Test()
        {
            EmailHandler handler = new EmailHandler();
            var response = handler.GetEmail(new GetEmailRequest());
        }
    }
}
