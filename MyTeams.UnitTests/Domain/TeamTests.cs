using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace MyTeams.UnitTests.Domain
{
    public class TeamTests
    {
        [Fact]
        public void Add_member_should_add_member_to_team_when_member_is_valid()
        {
            // Arrange
            var team = GetTeam();
            var memberId = Guid.NewGuid();
            var member = GetMember(memberId);

            // Act
            team.AddMember(member);

            // Assert
            team.Members.ShouldContain(member);
            team.Members.Count.ShouldBe(1);
        }

        [Fact]
        public void Add_member_should_throw_member_already_exists_exception_when_member_with_same_name_exists()
        {
            // Arrange
            var team = GetTeam();
            var memberId = Guid.NewGuid();
            var member1 = GetMember(memberId);
            team.AddMember(member1);

            var memberId2 = Guid.NewGuid();
            var member2 = GetMember(memberId);

            // Act & Assert
            var exception = Should.Throw<MemberAlreadyExistsException>(() => team.AddMember(member2));
            exception.Message.ShouldContain(member2.Name);
            exception.Message.ShouldContain(member2.FullName);
        }

        [Fact]
        public void Update_member_should_update_member_details_when_member_exists()
        {
            // Arrange
            var team = GetTeam();
            var member1 = GetMember(team.Id);
            team.AddMember(member1);

            var updatedName = "Lucas";
            var updatedFullName = "Podolski";
            var updatedEmail = "lucas.podolski@gmail.com";
            var updatedPhone = "987654321";

            // Act
            team.UpdateMember(member1.Id, updatedName, updatedFullName, updatedEmail, updatedPhone);

            // Assert
            var updatedMember = team.Members.Single(m => m.Id == member1.Id);
            updatedMember.Name.Value.ShouldBe(updatedName);
            updatedMember.FullName.Value.ShouldBe(updatedFullName);
            updatedMember.Email.Value.ShouldBe(updatedEmail);
            updatedMember.PhoneNumber.Value.ShouldBe(updatedPhone);
        }

        [Fact]
        public void Update_member_should_throw_entity_not_found_exception_when_member_does_not_exist()
        {
            // Arrange
            var team = GetTeam();
            var memberId = new MemberId(Guid.NewGuid());

            // Act & Assert
            var exception = Should.Throw<EntityNotFoundException>(() => 
            team.UpdateMember(memberId, 
            "Johnny", 
            "Doe", 
           "johnny.doe@example.com",
            "987654321"));
            exception.Message.ShouldContain(nameof(Member));
            exception.Message.ShouldContain(memberId.ToString());
        }

        [Fact]
        public void Update_satus_member_should_activate_member_when_member_exists_and_status_is_true()
        {
            // Arrange
            var team = GetTeam();
            var member = GetMember(team.Id, false);
            team.AddMember(member);

            // Act
            team.UpdateSatusMember(member.Id, true);

            // Assert
            var updatedMember = team.Members.Single(m => m.Id == member.Id);
            updatedMember.IsActive.ShouldBeTrue();
        }

        [Fact]
        public void Update_satus_member_should_deactivate_member_when_member_exists_and_status_is_false()
        {
            // Arrange
            var team = GetTeam();
            var member = GetMember(team.Id);
            team.AddMember(member);

            // Act
            team.UpdateSatusMember(member.Id, false);

            // Assert
            var updatedMember = team.Members.Single(m => m.Id == member.Id);
            updatedMember.IsActive.ShouldBeFalse();
        }

        [Fact]
        public void Update_status_member_should_throw_entity_not_found_exception_when_member_does_not_exist()
        {
            // Arrange
            var team = GetTeam();
            var memberId = new MemberId(Guid.NewGuid());

            // Act & Assert
            var exception = Should.Throw<EntityNotFoundException>(() => team.UpdateSatusMember(memberId, true));
            exception.Message.ShouldContain(nameof(Member));
            exception.Message.ShouldContain(memberId.ToString());
        }

        private Team GetTeam() => new Team(Guid.NewGuid(), "CR Team");
        private Member GetMember(Guid teamId, bool isActive = true) => Member.Create(Guid.NewGuid(),
                teamId,
                "John",
                "Doe",
                "john.doe@example.com",
                "123456789",
                "file.jpg",
                isActive);
    }
}

