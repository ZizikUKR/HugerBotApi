using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HuggerBotApi.Domain.Commands
{
    public class GetMenuCommand : Command
    {
        public GetMenuCommand(string botName):base(botName,"Menu")
        {
            Text = "Menu, as you asked, my Lord!";
        }
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, Text, ParseMode.Html, false, false, 0, GetMenu());
        }

        private ReplyKeyboardMarkup GetMenu()
        {
            var menu = new ReplyKeyboardMarkup();
            menu.Keyboard = new[]
            {
                new[]{
                new KeyboardButton("See all matches reviews"),
                new KeyboardButton("Weather"),
                new KeyboardButton("Enter Team Name"),
                }
            };

            return menu;
        }
    }
}
