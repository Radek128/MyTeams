using MyTeam.Application.Abstractions;

namespace MyTeam.Application.Commands
{
    public record UpdateStatusMember(Guid TeamId, Guid MemberId, bool isActiveStatus) : ICommand;
}
