using MyTeam.Application.Dto;

namespace MyTeam.Application.Abstractions
{
    public interface INotification
    {
        Task SendMessage(string teamId, MemberDto member);
    }
}
