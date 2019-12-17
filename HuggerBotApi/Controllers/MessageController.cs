using HuggerBotApi.Domain.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HuggerBotApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IBotProvider _botProvider;
        public MessageController(IBotProvider botProvider)
        {
            _botProvider = botProvider;
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody]Update update)
        {
            if (update == null)
            {
                throw new Exception("Invalid model");
            }
            await _botProvider.Update(update);
            return Ok();
        }
    }
}
