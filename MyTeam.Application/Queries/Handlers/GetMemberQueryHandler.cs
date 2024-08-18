using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;
using MyTeam.Application.Extensions;
using MyTeam.Domain.Entities;
using MyTeam.Domain.Exceptions;
using MyTeam.Domain.Repositories;

namespace MyTeam.Application.Queries.Handlers
{
    public class GetMemberQueryHandler : IQueryHandler<GetMember, MemberDto>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IFileService _fileService;

        public GetMemberQueryHandler(IMemberRepository memberRepository, IFileService fileService)
        {
            _memberRepository = memberRepository;
            _fileService = fileService;
        }

        public async Task<MemberDto> HandleAsync(GetMember query)
        {
            var result = await _memberRepository.GetByIdAsync(query.MemberId)
                ?? throw new EntityNotFoundException(typeof(Member), query.MemberId);
            return result.ToDto();
        }
    }
}
