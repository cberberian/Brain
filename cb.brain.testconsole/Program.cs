using System;
using System.Collections;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading;
using AIMLbot;
using cb.brain.commandProcessor;
using cb.brain.commandProcessor.entities;
using cb.brain.commandProcessor.interfaces;
using Moq;


namespace cb.brain.testconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var myBot = new Bot();
            myBot.loadSettings();
            var myUser = new User("consoleUser", myBot);
            myBot.IsAcceptingUserInput = false;
            myBot.LoadAimlFromFiles();
            myBot.IsAcceptingUserInput = true;
            var synth = new SpeechSynthesizer();
            var commandProcessorFactory = new Mock<ICommandProcessorFactory>();
            var innerprocessor = new Mock<ICommandProcessor>();
            
            commandProcessorFactory.Setup(x => x.GetCommandProcessor(It.IsAny<CommandRequest>())).Returns(innerprocessor.Object);
            var processor = new CommandProcessor(commandProcessorFactory.Object, myUser, myBot);
            var results = new[]
            {
                new CommandResult
                {
                    ResultType = CommandResultTypeEnum.Text,
                    Content = "Hello Dude",
                    Pause = 1000
                    
                },
                new CommandResult
                {
                    ResultType = CommandResultTypeEnum.Text,
                    Content = "How are you?"

                },

            };
            var resultQueue = new Queue<CommandResult>(results);
            
            var result = resultQueue.Dequeue();

            while (result != null)
            {
                var sayText = string.Empty;
                switch (result.ResultType)
                {
                    case CommandResultTypeEnum.Text:
                        sayText = result.Content;
                        break;
                    case CommandResultTypeEnum.Bot:
                        var r = new Request(result.Content, myUser, myBot);
                        var res = myBot.Chat(r);
                        sayText = res.Output;
                        break;
                }
                if (!string.IsNullOrEmpty(sayText))
                {
                    Console.WriteLine(sayText);
                    synth.Speak(sayText);
                }
                if (result.WaitInput)
                {
                    var line = Console.ReadLine();
                }
                else if (result.Pause > 0)
                    Thread.Sleep(result.Pause);
                if (resultQueue.Count == 0)
                    break;
                result = resultQueue.Dequeue();
            }
            Console.ReadLine();
        }
    }
}
