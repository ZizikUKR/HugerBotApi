using HuggerBotApi.Domain.Entities;
using RestSharp;
using RestSharp.Serialization.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HuggerBotApi.Domain.Commands
{
    public class WeatherCommand : Command
    {
        public WeatherCommand(string botName):base(botName,"Weather")
        {

        }
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var weatherClient = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=Kharkiv,ua&APPID=fbb8efaffc343bd861d88c50b2418b7e");
            var request = new RestRequest(Method.GET);
            var chatId = message.Chat.Id;
            IRestResponse response = weatherClient.Execute(request);
            if (string.IsNullOrWhiteSpace(response.Content))
            {
                Text = "Some problems with weather api";
                await client.SendTextMessageAsync(chatId, Text);
            }
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                WeatherExample responseContent = new JsonDeserializer().Deserialize<WeatherExample>(response);
                Text = $@"<strong>{responseContent?.Name}</strong><pre>Humidity: {responseContent.Main.Humidity}</pre><pre>Temperature: {responseContent?.Main?.Temp}</pre> <pre>Pressure: {responseContent?.Main?.Pressure}</pre>";
                
                await client.SendTextMessageAsync(chatId, Text, parseMode: ParseMode.Html);
            }          
        }
    }
}
