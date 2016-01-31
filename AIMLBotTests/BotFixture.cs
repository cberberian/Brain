using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using NUnit.Framework;

namespace AIMLBotTests
{
    [TestFixture]
    public class BotFixture
    {
        [Test]
        public void Test()
        {
            var bot = new Bot();

            var user = new User("me", bot);
            var request = new Request("test", user, bot);
            var result = bot.Chat(request);
        }
    }
}
