using MyTeam.Domain.Entities;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task<Team?> GetByIdAsync(TeamId teamId);
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
    }
}
