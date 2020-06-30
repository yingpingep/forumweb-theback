using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace forumweb_theback.Hubs
{
    public class ControlHub : Hub
    {
        public async Task<string> SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            return "ok";
        }
    }
}