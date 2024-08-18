using MySpot.Application.Abstractions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class CreateNewTeamHandler : ICommandHandler<CreateNewTeam>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateNewTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task HandleAsync(CreateNewTeam command)
        {
            Team team = new Team(command.NewTeamId);
            await _teamRepository.AddAsync(team);
        }
    }
}
