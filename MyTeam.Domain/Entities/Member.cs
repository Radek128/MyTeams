using MyTeam.Domain.ValueObjects;

namespace MyTeam.Domain.Entities
{
    public class Member
    {
        public MemberId Id { get; private set; }
        public TeamId TeamId { get; set; }
        public FirstName Name { get; private set; }
        public FullName FullName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public FileInformation Avatar { get; private set; }

        private Member()
        {
            
        }

        private Member(MemberId memberId,
            TeamId teamId,
            FirstName name,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber,
            FileInformation avatar,
            bool isActive)
        {
            Id = memberId;
            TeamId = teamId;
            Name = name;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            IsActive = isActive;
        }

        public static Member Create(MemberId memberId,
            TeamId teamId,
            FirstName name,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber,
            FileInformation avatar,
            bool isActive) 
            => new(memberId, teamId, name, fullName, email, phoneNumber, avatar, isActive); 

        internal void Update(FirstName name,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber)
        {
            Name = name;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        internal void Activate() 
        {
            if (!IsActive)
            {
                IsActive = true;
            }
        }

        internal void Deactivate()
        {
            if (IsActive)
            {
                IsActive = false;
            }
        }
    }
}
