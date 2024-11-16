using Microsoft.AspNetCore.SignalR;
using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;

namespace MyTeam.Infrastructure.WebHooks
{
    public class Notification : INotification
    {
        private readonly IHubContext<TeamHub, IAddMemberClient> _context;

        public Notification(IHubContext<TeamHub, IAddMemberClient> context)
        {
            _context = context;
        }

        public async Task SendMessage(string teamId, MemberDto member)
        {
            await _context.Clients.Group(teamId).NotifyNewMember(member);
        }
    }
}
