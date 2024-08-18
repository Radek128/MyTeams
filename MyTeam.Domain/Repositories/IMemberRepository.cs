using MyTeam.Domain.Entities;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync(TeamId teamId);
        Task<Member?> GetByIdAsync(MemberId teamId);
        Task UpdateAsync(Member member);
    }
}
