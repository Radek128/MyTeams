using Microsoft.AspNetCore.SignalR;
using MyTeam.Application.Abstractions;

namespace MyTeam.Infrastructure.WebHooks
{
    public sealed class TeamHub : Hub<IAddMemberClient>
    {
        public async Task JoinTeamGroup(string teamId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, teamId);
        }

        public async Task LeaveTeamGroup(string teamId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, teamId);
        }
    }
}
