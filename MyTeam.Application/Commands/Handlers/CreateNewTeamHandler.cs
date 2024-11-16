using MySpot.Application.Abstractions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Repositories;
using MyTeam.Domain.Services;

namespace MyTeam.Application.Commands.Handlers
{
    public class CreateNewTeamHandler : ICommandHandler<CreateNewTeam>
    {
        private readonly ITeamDomainService _teamDomaindService;

        public CreateNewTeamHandler(ITeamDomainService teamRepository)
        {
            _teamDomaindService = teamRepository;
        }

        public async Task HandleAsync(CreateNewTeam command)
        {
            Team team = new Team(command.NewTeamId, command.Name);
            await _teamDomaindService.AddTeam(team);
        }
    }
}
