using HuggerBotApi.Domain.Entities;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HuggerBotApi.Domain.Commands
{
    public class ChooseMatchCommand : Command
    {
        public ChooseMatchCommand(string botName) : base(botName, "/team")
        {
            Text = "One Match";
        }

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var team = message.Text.Replace("/team", "");

            List<FootballVideo> matches = GetAll().ToList();
            var res = string.Empty;
            var match = matches.FirstOrDefault(m => m.Title.ToLower().Contains(team.ToLower()));
            if (match is null)
            {
                await client.SendTextMessageAsync(chatId, "No matches or wrong team name");
            }
            else
            {
                res = $"<a href='{match.Url}'>{match.Title}</a><pre></pre>";
                await client.SendTextMessageAsync(chatId, res, parseMode: ParseMode.Html);
            }
            
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
