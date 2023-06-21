using Microsoft.AspNetCore.SignalR;

namespace SignalRApp.Hubs;

public class PrivateChatHub : Hub
{
    public string GetConnectionId() => Context.ConnectionId;

    public async Task SendPrivate(string user, string receiverConnectionId, string message)
    {
        await Clients.Client(receiverConnectionId).SendAsync("Receive", user, message);
    }
}