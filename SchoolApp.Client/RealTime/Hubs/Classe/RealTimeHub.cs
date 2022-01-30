using SchoolApp.Client.RealTime.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;

namespace SchoolApp.Client.RealTime.Hubs.Classe;
public class RealTimeHub : Hub, IRealTimeHub
{
    IHubContext<RealTimeHub> _hubContext;
    private IList<string> ConnectedUsers { get; set; }
    public RealTimeHub(
        IHubContext<RealTimeHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public override async Task OnConnectedAsync()
    {
        ConnectedUsers.Add(Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public IList<string> GetConnectedUsersList()
    {
        return ConnectedUsers;
    }

    public async Task SendToAll(object[] entities)
    {
        await _hubContext.Clients.All.SendCoreAsync("SendToAll", entities);
    }

    public async Task SendToSpecifiOnes(object[] entities, IList<string> specificUsersIds)
    {
        foreach (var userId in specificUsersIds)
        {
            await _hubContext.Clients.Client(userId).SendCoreAsync("SendToSpecifiOnes", entities);
        }
    }
}
