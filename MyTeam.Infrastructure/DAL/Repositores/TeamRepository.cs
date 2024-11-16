using Microsoft.EntityFrameworkCore;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Repositories;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Infrastructure.DAL.Repositores
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamDbContext _teamDbContext;

        public TeamRepository(TeamDbContext teamDbContext)
        {
            _teamDbContext = teamDbContext;
        }

        public async Task AddAsync(Team team)
        {
            await _teamDbContext.AddAsync(team);
            await _teamDbContext.SaveChangesAsync();
        }

        public Task<bool> CheckIfTeamNameIsInUse(TeamName teamName) 
            => _teamDbContext.Teams.AnyAsync(x => x.Name == teamName);
        

        public Task<Team?> GetByIdAsync(TeamId teamId)
            => _teamDbContext.Teams
            .Include(x => x.Members)
            .SingleOrDefaultAsync(x => x.Id == teamId);
        
        public async Task UpdateAsync(Team team)
        {
            _teamDbContext.Update(team);
            await _teamDbContext.SaveChangesAsync();
        }
    }
}
