using MyTeam.Application.Abstractions;

namespace MyTeam.Application.Commands
{
    public record CreateNewTeam(Guid NewTeamId) : ICommand;
}
