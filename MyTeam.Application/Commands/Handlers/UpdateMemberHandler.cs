using MySpot.Application.Abstractions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class UpdateMemberHandler : ICommandHandler<UpdateMember>
    {

        private readonly IMemberRepository _memberRepository;

        public UpdateMemberHandler(IMemberRepository teamRepository)
        {
            _memberRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }
        public async Task HandleAsync(UpdateMember command)
        {
            var member = await _memberRepository.GetByIdAsync(command.MemberId) 
                ?? throw new EntityNotFoundException(typeof(Member), command.MemberId);
            member.Update(command.FirstName, command.LastName, command.Email, command.PhoneNumber);
            await _memberRepository.UpdateAsync(member);
        }
    }
}
