using MyTeam.Application.Abstractions;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Application.Commands
{
    public record DeleteMemberTeam (TeamId teamId, MemberId MemberId) : ICommand;
}
