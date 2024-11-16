using MyTeam.Application.Dto;

namespace MyTeam.Application.Abstractions
{
    public interface IAddMemberClient
    {
        Task NotifyNewMember(MemberDto newMember);
    }
}
