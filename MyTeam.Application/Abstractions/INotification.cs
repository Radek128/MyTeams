using MyTeam.Application.Dto;

namespace MyTeam.Application.Abstractions
{
    public interface INotification
    {
        Task SendMessage(string teamName, MemberDto member);
    }
}
