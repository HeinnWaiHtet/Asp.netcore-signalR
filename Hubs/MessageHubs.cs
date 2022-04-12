using Microsoft.AspNetCore.SignalR;

namespace Asp.netCoreSignlaR.Hubs
{
    public class MessageHubs: Hub
    {
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
