using MySpot.Application.Abstractions;
using MyTeam.Application.Abstractions;
using MyTeam.Application.Extensions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Commands.Handlers
{
    public class CreateNewMemberHandler : ICommandHandler<CreateNewMember>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IFileService _fileService;
        private readonly INotification _notification;

        public CreateNewMemberHandler(ITeamRepository teamRepository,
            IFileService fileService,
            INotification notification)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _notification = notification ?? throw new ArgumentNullException(nameof(notification));
        }

        public async Task HandleAsync(CreateNewMember command)
        {
            var team = await _teamRepository.GetByIdAsync(command.TeamId) 
                ?? throw new EntityNotFoundException(typeof(Team), command.TeamId);
            Member newMember = Member.Create(command.MemberId,
                command.TeamId,
                command.FirstName, 
                command.LastName, 
                command.Email, 
                command.PhoneNumber,
                command.Avatar, 
                true);
            team.AddMember(newMember);
            await _teamRepository.UpdateAsync(team);
            await _notification.SendMessage(team.Name, newMember.ToDto());
        }
    }
}
