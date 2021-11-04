using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace saltBot4._0
{
    class Program
    {

        public string TOKEN = System.IO.File.ReadAllText(@"C:\Users\Komand\Desktop\saltBot4.0\token\TokeN.txt");
        private DiscordSocketClient theBot;
        private bool askedforsalt = false;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        //får botten online og fortæller den hvad den skal gøre
        public async Task MainAsync()
        {
            theBot = new DiscordSocketClient();
            theBot.Log += Log;
            theBot.MessageReceived += MessageReceived;

            await theBot.LoginAsync(TokenType.Bot, TOKEN);
            await theBot.StartAsync();
            await Task.Delay(-1);
        }
        //logger bottens aktivitet
        private Task Log (LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;           
        }
        //håndtere beskeder som botten modtager og hvad den skal svare
        private async Task MessageReceived(SocketMessage message)
        {
            if(message.Content.ToLower().Contains("you gay") && !message.Author.IsBot)
            {
                await message.Channel.SendMessageAsync("no u");
                askedforsalt = false;
            }
            else if (message.Content.ToLower().Contains("salt") && !message.Author.IsBot)
            {
                await message.Channel.SendMessageAsync("Bruh you want some salt?");
                await message.Channel.SendMessageAsync(":salt:");
                askedforsalt = true;
            }            
            else if(message.Content.ToLower().Contains("yes") && askedforsalt && !message.Author.IsBot)
            {
                await message.Channel.SendMessageAsync(":salt::salt::salt::salt::salt:");
                await message.Channel.SendMessageAsync(":salt::salt::salt::salt::salt:");
                await message.Channel.SendMessageAsync(":salt::salt::salt::salt::salt:");
                await message.Channel.SendMessageAsync("you welcome ;)))))");
                askedforsalt = false;
            }
            else if(message.Content.ToLower().Contains("no")  && askedforsalt && !message.Author.IsBot)
            {
                await message.Channel.SendMessageAsync("fack you!");
                await message.Channel.SendMessageAsync(":,(");
                askedforsalt = false;
            }
        }
    }
}
