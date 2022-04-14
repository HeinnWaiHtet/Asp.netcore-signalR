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

        /// <summary>
        /// Send Message To Specific UserId
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// Join Group By Connection Id
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        /// <summary>
        /// Send Message  by group
        /// </summary>
        /// <param name="group"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToGroup(string group, string message)
        {
            return Clients.Group(group).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            /** add connection UserId */
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            /** clear connection UserId */
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
