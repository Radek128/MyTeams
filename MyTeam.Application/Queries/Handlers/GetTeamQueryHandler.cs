using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;
using MyTeam.Application.Extensions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Queries.Handlers
{
    public class GetTeamQueryHandler : IQueryHandler<GetTeam, TeamDto>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamDto> HandleAsync(GetTeam query)
        {
            var result = await _teamRepository.GetByIdAsync(query.TeamId) 
                ?? throw new EntityNotFoundException(typeof(Team), query.TeamId); ;
            return new TeamDto(result.Id, result.Name, result.Members.Select( x => x.ToDto()));
        }
    }
}
