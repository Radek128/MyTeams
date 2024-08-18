using MyTeam.Application.Dto;
using MyTeam.Domain.Entities;

namespace MyTeam.Application.Extensions
{
    public static class MemberExtensions
    {
        public static MemberDto ToDto(this Member member) 
            => new(member);
    }
}
