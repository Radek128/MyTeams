using MyTeam.Domain.Entities;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Application.Dto
{
    public sealed record MemberDto
    {
        public Guid MemberId { get; init; }
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string Avatar { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedOn { get; init; }

        public MemberDto(Member member)
        {
            LastName = member.FullName;
            FirstName = member.Name;
            PhoneNumber = member.PhoneNumber;
            Email = member.Email;
            MemberId = member.Id;
            Avatar = member.Avatar;
            CreatedOn = member.CreatedOn;
            IsActive = member.IsActive;
        }
    }
}
