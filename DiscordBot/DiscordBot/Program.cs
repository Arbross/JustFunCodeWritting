using System;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{ 
    class Program
    {
        DiscordSocketClient client;
        static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
        async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += Client_MessageReceived;

            string token = "";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private static void LogAuthor(SocketMessage arg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO {DateTime.Now}] Username : {arg.Author.Username}, avatar id : {arg.Author.AvatarId}, status : {arg.Author.Status}");
        }

        private Task Client_MessageReceived(SocketMessage arg)
        {
            if (arg.Author.Username == "RpgBot" && arg.Author.IsBot == true)
            {
                return Task.CompletedTask;
            }

            string msg = arg.Content.ToLower();
            if (msg.Contains("ы"))
            {
                arg.Channel.SendMessageAsync("Русский корабль іди нахуй!");
                LogAuthor(arg);
            }
            else if (msg.Contains("тоха") || msg.Contains("антон"))
            {
                arg.Channel.SendMessageAsync("Тоха гей!");
                LogAuthor(arg);
            }

            return Task.CompletedTask;
        }
    }
}
