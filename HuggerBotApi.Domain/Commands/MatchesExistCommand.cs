using HuggerBotApi.Domain.Entities;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HuggerBotApi.Domain.Commands
{
    public class MatchesExistCommand : Command
    {
        public MatchesExistCommand(string botName):base(botName,"List of Matches")
        {
            Text = "";
        }
        public override void Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }

        private string GetAllMatches(string commandName)
        {
            List<FootballVideo> matches = GetAll().ToList();
            var res = string.Empty;
            
            //foreach (var match in matches)
            //{
            //    res.Add($"<a href='{match.Url}'>{match.Title}</a><pre></pre>");
            //}
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
