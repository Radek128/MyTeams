using Microsoft.EntityFrameworkCore;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Repositories;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Infrastructure.DAL.Repositores
{
    public class MemberRepository : IMemberRepository
    {
        private readonly TeamDbContext _teamDbContext;

        public MemberRepository(TeamDbContext teamDbContext)
        {
            _teamDbContext = teamDbContext;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync(TeamId teamId)
        {
            var result = await _teamDbContext.Members
                 .AsNoTracking()
                 .Where(x => x.TeamId == teamId)
                 .OrderByDescending(x => x.CreatedOn)
                 .ToListAsync();

            return result ?? [];
        }

        public Task<Member?> GetByIdAsync(MemberId memberId)
            => _teamDbContext.Members.SingleOrDefaultAsync(x => x.Id == memberId);

        public async Task UpdateAsync(Member member)
        {
            _teamDbContext.Update(member);
            await _teamDbContext.SaveChangesAsync();
        }
    }
}
