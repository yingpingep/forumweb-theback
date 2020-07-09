using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using forumweb_theback.Models;

namespace forumweb_theback.Hubs
{
    public class ControlHub : Hub, IManipulateR
    {
        public async Task SendChangePage(PageType page)
        {
            await Clients.All.SendAsync("ReceiveChangePage", page);
        }

        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendQuestion(Question question)
        {            
            await Clients.All.SendAsync("ReceiveQuestion", question);
        }

        public async Task CloseQuestion(bool shouldClose)
        {
            await Clients.All.SendAsync("QuestionClosed", shouldClose);
        }
    }
}