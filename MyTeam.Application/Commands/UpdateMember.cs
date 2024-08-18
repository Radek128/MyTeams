using MyTeam.Application.Abstractions;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Application.Commands
{
    public sealed record UpdateMember : ICommand
    {
        public Guid MemberId { get; init; }
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
    }
}
