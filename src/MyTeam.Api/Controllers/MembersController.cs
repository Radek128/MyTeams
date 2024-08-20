using Microsoft.AspNetCore.Mvc;
using MySpot.Application.Abstractions;
using MyTeam.Application.Abstractions;
using MyTeam.Application.Commands;
using MyTeam.Application.Dto;
using MyTeam.Application.Queries;

namespace MyTeam.Api.Controllers
{
    [ApiController]
    [Route("teams")]
    public class MembersController : ControllerBase
    {

        private readonly IQueryHandler<GetMember, MemberDto> _getMemberHandler;
        private readonly IQueryHandler<GetMembers, IEnumerable<MemberDto>> _getAllMembersHandler;
        private readonly ICommandHandler<CreateNewMember> _createNewMemeberHandler;
        private readonly ICommandHandler<UpdateMember> _updateMemberHandler;
        private readonly ICommandHandler<UpdateStatusMember> _updateMemberStatusHandler;

        public MembersController(ICommandHandler<UpdateMember> updateMemberHandler, 
            ICommandHandler<CreateNewMember> createNewMemeberHandler,
            ICommandHandler<UpdateStatusMember> commandHandler,
            IQueryHandler<GetMembers, IEnumerable<MemberDto>> getAllMembersHandler,
            IQueryHandler<GetMember, MemberDto> getMemberHandler)
        {
            _updateMemberHandler = updateMemberHandler;
            _createNewMemeberHandler = createNewMemeberHandler;
            _getAllMembersHandler = getAllMembersHandler;
            _getMemberHandler = getMemberHandler;
            _updateMemberStatusHandler = commandHandler;
        }

        [HttpGet("members/{memberId}")]
        public async Task<ActionResult<MemberDto>> Get(Guid memberId)
        {
            return Ok(await _getMemberHandler.HandleAsync(new() { MemberId = memberId}));
        }

        [HttpGet("{teamId}/members")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll(Guid teamId)
        {
            return Ok(await _getAllMembersHandler.HandleAsync(new(){ TeamId = teamId }));
        }

        [HttpPost("{teamId}/members")]
        public async Task<ActionResult> Add(Guid teamId, CreateNewMember createNewMember)
        {
            await _createNewMemeberHandler.HandleAsync(createNewMember with 
            { 
                TeamId = teamId, 
            });
            return Ok();
        }

        [HttpPut("members/{memberId}")]
        public async Task<ActionResult> Update(Guid memberId, UpdateMember updateMember)
        {
            await _updateMemberHandler.HandleAsync(updateMember with { MemberId = memberId});
            return Ok();
        }

        [HttpPut("members/{memberId}/status")]
        public async Task<ActionResult> Update(Guid memberId, UpdateStatusMember updateMemberStatus)
        {
            await _updateMemberStatusHandler.HandleAsync(updateMemberStatus with { MemberId = memberId });
            return Ok();
        }
    }
}
