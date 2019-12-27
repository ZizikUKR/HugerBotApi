using System;

namespace HuggerBotApi.Domain.Entities
{
    public class FootballVideo
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public string Url { get; set; }

        public Competition Competition { get; set; }
    }
}
