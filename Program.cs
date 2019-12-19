using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;

namespace AIMLTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot AI = new Bot();
            AI.loadSettings();
            AI.loadAIMLFromFiles();

            AI.isAcceptingUserInput = false;

            User myUser = new User("username", AI);
            AI.isAcceptingUserInput = true;

            while (true)
            {
                Request r = new Request(Console.ReadLine(), myUser, AI);
                Result res = AI.Chat(r);
                Console.WriteLine("Robot: " + res.Output);
            }
        }
    }
}
