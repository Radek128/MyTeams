using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Domain.Services
{
    public class TeamDomainService : ITeamDomainService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamDomainService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task AddTeam(Team team)
        {
            var result = await _teamRepository.CheckIfTeamNameIsInUse(team.Name);
            if(!result)
            {
                await _teamRepository.AddAsync(team);
            }

            throw new TeamNameAlreadyInUseException("Team name is already in use");
        }
    }
}
