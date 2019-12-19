using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HuggerBotApi.Domain.Commands
{
    public class HelloCommand : Command
    {
        public HelloCommand(string botName) : base(botName, "hello")
        {
            Text = @"It's pleasure to see you again, my Lord!
                        Whould you like to see football reviews?";

        }

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, Text, ParseMode.Html,false,false,0, GetMenu());
        }

        private ReplyKeyboardMarkup GetMenu()
        {
            var menu = new ReplyKeyboardMarkup();
            menu.Keyboard = new[]
            {
                new[]{
                new KeyboardButton("Yes"),
                new KeyboardButton("No")
                }
            };

            return menu;
        }
    }
}
