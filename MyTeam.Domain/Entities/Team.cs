using MyTeam.Domain.ValueObjects;

namespace MyTeam.Domain.Entities
{
    public class Team
    {
        public TeamId Id { get; private set; }
        public TeamName Name { get; set; }
        public IReadOnlyCollection<Member> Members => _members.AsReadOnly();
        private List<Member> _members = new();
        public Team()
        {
            
        }
        public Team(TeamId id, TeamName teamName)
        {
            Id = id;
            Name = teamName;
        }

        public void AddMember(Member member) 
        {
            _members.Add(member);
        }
    }
}
