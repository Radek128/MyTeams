using MyTeam.Domain.Exceptions;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Domain.Entities
{
    public class Team
    {
        public TeamId Id { get; private set; }
        public TeamName Name { get; private set; }
        public IReadOnlyCollection<Member> Members => _members.AsReadOnly();
        private List<Member> _members = new();
        private Team()
        {
            
        }
        public Team(TeamId id, TeamName teamName)
        {
            Id = id;
            Name = teamName;
        }

        public void AddMember(Member member)
        {
            ValidateMember(member);
            _members.Add(member);
        }

        public void UpdateMember(MemberId memberId, FirstName name,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber)
        {
            Member member = FindMemberById(memberId);
            ValidateMemberName(name, fullName);
            member.Update(name, fullName, email, phoneNumber);
        }

        public void UpdateSatusMember(MemberId memberId, bool isActiveStatus)
        {
            Member member = FindMemberById(memberId);

            if (isActiveStatus)
            {
                member.Activate();
            }
            else
            {
                member.Deactivate();
            }
        }

        private Member FindMemberById(MemberId memberId)
        {
            Member? member = _members.SingleOrDefault(x => x.Id == memberId);

            if (member is null)
            {
                throw new EntityNotFoundException(typeof(Member), memberId);
            }

            return member;
        }

        private void ValidateMember(Member member) => ValidateMemberName(member.Name, member.FullName);

        private void ValidateMemberName(FirstName firstName, FullName fullName)
        {
            var alreadyExists = _members.Any(x => x.Name == firstName
                && x.FullName == fullName);

            if (alreadyExists)
            {
                throw new MemberAlreadyExistsException(firstName, fullName);
            }
        }
    }
}
