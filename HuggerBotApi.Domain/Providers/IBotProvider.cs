using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HuggerBotApi.Domain.Providers
{
    public interface IBotProvider
    {
        Task Update(Update update);
        Task InitializeClient();
    }
}
