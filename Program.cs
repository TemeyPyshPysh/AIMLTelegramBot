using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.IO;
using System.Net;

namespace AIMLTelegramBot
{
    class Program
    {
        private static ITelegramBotClient botClient;
        private static Bot AI;
        private static User myUser;
        private static string LoadKey(string pathToFile)
        {
            StreamReader sr = new StreamReader(pathToFile);
            string key = sr.ReadLine().Replace(" ", string.Empty);

            return key;
        }
        static void Main(string[] args)
        {
            AI = new Bot();
            AI.loadSettings();
            AI.loadAIMLFromFiles();

            AI.isAcceptingUserInput = false;

            myUser = new User("username", AI);
            AI.isAcceptingUserInput = true;

            string pathToFile = "config/bot_key";
            string accessToken = LoadKey(pathToFile);

            var proxy = new WebProxy("20.40.147.38:8080");

            botClient = new TelegramBotClient(accessToken, proxy);
            var me = botClient.GetMeAsync().Result;

            Console.WriteLine(
                $"I'M ALIVE 4AW3 1S {me.Id} :: {me.FirstName}"
            );
            while (true)
            {
                Request r = new Request(Console.ReadLine(), myUser, AI);
                Result res = AI.Chat(r);
                Console.WriteLine("Robot: " + res.Output);
            }
        }
    }
}
