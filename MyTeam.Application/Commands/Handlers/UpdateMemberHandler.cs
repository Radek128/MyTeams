using MySpot.Application.Abstractions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class UpdateMemberHandler : ICommandHandler<UpdateMember>
    {
        private readonly ITeamRepository _teamRepository;

        public UpdateMemberHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }
        public async Task HandleAsync(UpdateMember command)
        {
            var team = await _teamRepository.GetByIdAsync(command.TeamId) 
                ?? throw new EntityNotFoundException(typeof(Team), command.TeamId);
            team.UpdateMember(command.MemberId,
                command.FirstName, 
                command.LastName,
                command.Email, 
                command.PhoneNumber);
            await _teamRepository.UpdateAsync(team);
        }
    }
}
