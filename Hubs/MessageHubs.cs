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

        /// <summary>
        /// Send Message To Caller Using Client.Caller
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
