using MyTeam.Domain.Entities;

namespace MyTeam.Domain.Services
{
    public interface ITeamDomainService
    {
        Task AddTeam(Team team);
    }
}