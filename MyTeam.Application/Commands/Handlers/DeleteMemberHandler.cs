using MySpot.Application.Abstractions;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class DeleteMemberHandler : ICommandHandler<DeleteMemberTeam>
    {
        private readonly ITeamRepository _repository;

        public DeleteMemberHandler(ITeamRepository teamRepository)
        {
            _repository = teamRepository;
        }

        public async  Task HandleAsync(DeleteMemberTeam command)
        {
            var team = await _repository.GetByIdAsync(command.teamId)
                ?? throw new EntityNotFoundException(typeof(DeleteMemberTeam), command.teamId);

            await _repository.UpdateAsync(team);
        }
    }
}
