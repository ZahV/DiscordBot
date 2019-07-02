using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot
{
    internal class Program
    {

        private DiscordSocketClient Client;
        private CommandService Commands;

        private static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();


        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;


            string token = "";
            using (var Stream = new FileStream(@"Data\Token.txt", FileMode.Open, FileAccess.Read))
            using (var ReadToken = new StreamReader(Stream))
            {
                token = ReadToken.ReadToEnd();
            }
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task Client_MessageReceived(SocketMessage MessageParam)
        {
            var message = MessageParam as SocketUserMessage;
            var context = new SocketCommandContext(Client, message);

            if (context.Message == null || context.Message.Content == "")
            {
                return;
            }

            if (context.User.IsBot)
            {
                return;
            }

            int argPos = 0;
            if (!(message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos)))
            {
                return;
            }

            var result = await Commands.ExecuteAsync(context, argPos, null);
            if (!result.IsSuccess)
            {
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing a command. Text: {context.Message.Content} | Error: {result.ErrorReason} ");
            }
        }

        private async Task Client_Ready()
        {
            await Client.SetGameAsync("!help for more info");
        }


#pragma warning disable 1998
        private async Task Client_Log(LogMessage message)
        {
            Console.WriteLine($"{DateTime.Now} at {message.Source}] {message.Message}");
        }
#pragma warning restore 1998
    }


}
