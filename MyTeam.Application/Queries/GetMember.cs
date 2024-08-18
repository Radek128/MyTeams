using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;

namespace MyTeam.Application.Queries
{
    public record GetMember : IQuery<MemberDto>
    {
        public Guid MemberId { get; set; }
    }
}
