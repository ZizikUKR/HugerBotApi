using HuggerBotApi.Domain.Entities;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HuggerBotApi.Domain.Commands
{
    public class AllMatchesCommand : Command
    {
        public AllMatchesCommand(string botName) : base(botName, "See all matches reviews")
        {
            Text = "Matches:";
        }
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var res = GetAllMatches();
            if (!res.Any())
            {
                await client.SendTextMessageAsync(chatId,"No matches last weekend!");
            }
            foreach (var item in res)
            {
                await client.SendTextMessageAsync(chatId, item, parseMode: ParseMode.Html);
            }
            
        }
            
        private IEnumerable<string> GetAllMatches()
        {
            List<FootballVideo> matches = GetAll().ToList();
            var res = new List<string>();
            foreach (var match in matches)
            {
                res.Add($"<a href='{match.Url}'>{match.Title}</a><pre></pre>");
            }
            return res;
        }

        private IEnumerable<FootballVideo> GetAll()
        {
            var client = new RestClient("https://free-football-soccer-videos.p.rapidapi.com/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "free-football-soccer-videos.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "38f02d5b9emshc23f324602a7bd8p14c025jsna25a0fd32533");
            IRestResponse response = client.Execute(request);
            List<FootballVideo> responseContent = new JsonDeserializer().Deserialize<List<FootballVideo>>(response);
            return responseContent;
        }

    }
}
