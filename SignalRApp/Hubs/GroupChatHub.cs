using Microsoft.AspNetCore.SignalR;

namespace SignalRApp.Hubs;

public class GroupChatHub : Hub
{
    public async Task JoinGroup(string user, string group)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
        await Clients.Group(group).SendAsync("Receive",
            "NOTIFY", $"{user} has joined group {group}");
    }

    public async Task SendToGroup(string user, string group, string message)
    {
        await Clients.Group(group).SendAsync("Receive", user, message);
    }

    public async Task ExitFromGroup(string user, string group)
    {
        await Clients.Group(group).SendAsync("Receive",
            "NOTIFY", $"{user} has left group {group}");
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
    }
}