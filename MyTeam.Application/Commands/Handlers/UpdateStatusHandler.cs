using MySpot.Application.Abstractions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class UpdateStatusHandler : ICommandHandler<UpdateStatusMember>
    {
        private readonly ITeamRepository _teamRepository;

        public UpdateStatusHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task HandleAsync(UpdateStatusMember command)
        {
            var member = await _teamRepository.GetByIdAsync(command.TeamId)
                ?? throw new EntityNotFoundException(typeof(Team), command.TeamId);
            member.UpdateSatusMember(command.MemberId, command.isActiveStatus);
            await _teamRepository.UpdateAsync(member);
        }
    }
}
