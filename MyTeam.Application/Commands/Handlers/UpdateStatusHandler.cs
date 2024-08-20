using MySpot.Application.Abstractions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class UpdateStatusHandler : ICommandHandler<UpdateStatusMember>
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateStatusHandler(IMemberRepository teamRepository)
        {
            _memberRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task HandleAsync(UpdateStatusMember command)
        {
            var member = await _memberRepository.GetByIdAsync(command.MemberId)
                ?? throw new EntityNotFoundException(typeof(Member), command.MemberId);
            if (command.isActiveStatus)
            {
                member.Activate();
            }
            else 
            {
                member.Deactivate();
            }

            await _memberRepository.UpdateAsync(member);
        }
    }
}
