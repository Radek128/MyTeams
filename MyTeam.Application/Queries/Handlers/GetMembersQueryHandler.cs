using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;
using MyTeam.Application.Extensions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Queries.Handlers
{
    public class GetMembersQueryHandler : IQueryHandler<GetMembers, IEnumerable<MemberDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IFileService _fileService;

        public GetMembersQueryHandler(IMemberRepository memberRepository, IFileService fileService)
        {
            _memberRepository = memberRepository;
            _fileService = fileService;
        }

        public async Task<IEnumerable<MemberDto>> HandleAsync(GetMembers query)
        {
            var members = await _memberRepository.GetAllMembersAsync(query.TeamId) 
                ?? throw new EntityNotFoundException(typeof(Member), query.TeamId);
            return members.Select(x => x.ToDto());
        }
    }
}
