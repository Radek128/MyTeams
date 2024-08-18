using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;

namespace MyTeam.Application.Queries
{
    public record GetMembers : IQuery<IEnumerable<MemberDto>>
    {
        public Guid TeamId { get; set; }
    }
}
