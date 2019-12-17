using HuggerBotApi.Domain.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HuggerBotApi.Domain.Providers
{
    public class BotProvider : IBotProvider
    {
        private TelegramBotClient _client;
        private readonly string _key;
        private readonly string _botName;
        private readonly string _url;
        private List<Command> _commands;
        public IReadOnlyList<Command> Commands { get => _commands.AsReadOnly(); }
        public BotProvider(IConfiguration configuration)
        {
            _key = configuration["Key"];
            _botName = configuration["BotName"];
            _url = configuration["Url"];
        }

        //private async Task<TelegramBotClient> Get()
        //{
        //    if (_client != null)
        //    {
        //        return _client;
        //    }
        //    _commands = new List<Command>();
        //    _commands.Add(new HelloCommand(_botName));

        //    _client = new TelegramBotClient(_key);
        //    await _client.SetWebhookAsync(_url);
        //    return _client;
        //}
        public async Task InitializeClient()
        {
            if (_client == null)
            {
                _commands = new List<Command>();
                _commands.Add(new HelloCommand(_botName));

                _client = new TelegramBotClient(_key);
                try
                {
                    await _client.SetWebhookAsync(_url);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task Update(Update update)
        {
            await InitializeClient();
            foreach (var command in Commands)
            {
                if (command.Contains(update.Message.Text))
                {
                    command.Execute(update.Message, _client);
                    break;
                }
            }
        }
    }
}
