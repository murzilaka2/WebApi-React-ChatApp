using ChatServer.Data;
using ChatServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ShareDb _shareDb;

        public ChatHub(ShareDb shareDb)
        {
            _shareDb = shareDb;
        }

        public async Task SendMessage(string message)
        {
            if (_shareDb.Connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                await Clients.Group(userConnection.ChatRoom).SendAsync("ReceiveSpecificMessage", userConnection.UserName, message);
            }
        }

        public async Task JoinChat(UserConnection userConnection)
        {
            await Clients.All
                .SendAsync("ReceiveMessage", "admin", $"{userConnection.UserName} has joined!");
        }
        public async Task JoinSpecificChatRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.ChatRoom);
            _shareDb.Connections[Context.ConnectionId] = userConnection;
            await Clients.Group(userConnection.ChatRoom)
                .SendAsync("ReceiveMessage", "admin", $"{userConnection.UserName} has joined {userConnection.ChatRoom}!");
        }
    }
}
