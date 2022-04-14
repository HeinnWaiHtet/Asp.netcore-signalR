using Microsoft.AspNetCore.SignalR;

namespace Asp.netCoreSignlaR.Hubs
{
    public class MessageHubs: Hub
    {
        /// <summary>
        /// Send Messages To All Connected Client
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
