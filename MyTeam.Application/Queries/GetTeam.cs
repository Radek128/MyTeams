using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;

namespace MyTeam.Application.Queries
{
    public class GetTeam : IQuery<TeamDto>
    {
        public Guid TeamId { get; set; }
    }
}
