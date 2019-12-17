using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HuggerBotApi.Domain.Commands
{
    public class HelloCommand : Command
    {
        public HelloCommand(string botName) : base(botName, "hello")
        {
            Text = "It's pleasure to see you again, my Lord!";
        }

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, Text, replyToMessageId:messageId);
        }
    }
}
