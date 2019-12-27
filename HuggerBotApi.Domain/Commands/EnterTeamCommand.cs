using Telegram.Bot;
using Telegram.Bot.Types;

namespace HuggerBotApi.Domain.Commands
{
    public class EnterTeamCommand : Command
    {
        public EnterTeamCommand(string botName):base(botName,"Enter Team Name")
        {
            Text = "Please enter: /team 'choosen team' .As example if you want to see last chelsea game, plese write -  /team chelsea ";
        }
        public async override void Execute(Message message, TelegramBotClient client)
        {
            // var inlineButtons = new List<InlineKeyboardButton>();
            //inlineButtons.Add(InlineKeyboardButton.WithCallbackData("Please write team manualy", "Match"));

            //var replyMarkap = new InlineKeyboardMarkup(inlineButtons);
            var chatId = message.Chat.Id;
            //var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, Text);
        }
    }
}
