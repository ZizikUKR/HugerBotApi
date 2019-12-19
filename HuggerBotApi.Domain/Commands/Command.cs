using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HuggerBotApi.Domain.Commands
{
    public abstract class Command 
    {
        public readonly string _botName;
        public readonly string _name;
        public string Text { get; set; }

        public Command(string botName,string commandName)
        {
            _botName = botName;
            _name = commandName;
        }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.ToLower().Contains(this._name.ToLower());
        }
    }
}
