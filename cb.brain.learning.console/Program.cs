using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using cb.brain.commandProcessor.processors;

namespace cb.brain.learning.console
{
    class Program
    {
        private static Bot _bot;
        private static User _user;
        private static readonly SpeechSynthesizer Synth = new SpeechSynthesizer();
        static void Main(string[] args)
        {
            _bot = InstantiateBot();
            _user = new User("chris", _bot);
            var input = string.Empty;
            Console.WriteLine("Say somthing to begin teaching me.");
            while (input.ToLower() != "q")
            {
                input = GetUserInput();
                if (input.StartsWith("/"))
                {
                    if (input.StartsWith("/bot"))
                        ProcessBotCommand(input);
                    if (input == "/save")
                    {
                        SaveBot();
                        continue;
                    }
                }

                var request = new Request(input, _user, _bot);
                var response = _bot.Chat(request);
                TellUser(response);

            }
        }

        private static void ProcessBotCommand(string input)
        {
            var arBotCommand = input.Split(' ');
            if (arBotCommand.Length != 3)
                Console.WriteLine("Bot command should be in format /bot name value");
            
        }

        private static void TellUser(Result response)
        {
            var output = response.Output;
            if (string.IsNullOrEmpty(output))
            {
                output = "no bot output for that";
            }
            Console.WriteLine(output);
            Synth.Speak(output);

        }

        private static Bot InstantiateBot()
        {
            var bot = new Bot
            {
                IsAcceptingUserInput = false
            };
            bot.loadSettings();
            var combine = Path.Combine(ConfigurationManager.AppSettings.Get("aimldirectory"), "Bot.bin");
            if (File.Exists(combine))
                bot.LoadFromBinaryFile(combine);
            else 
                bot.LoadAimlFromFiles();
            bot.IsAcceptingUserInput = true;
            return bot;
        }

        private static void SaveBot()
        {
            _bot.SaveToBinaryFile(Path.Combine(ConfigurationManager.AppSettings.Get("aimldirectory"), "Bot.bin"));
        }

        private static string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
