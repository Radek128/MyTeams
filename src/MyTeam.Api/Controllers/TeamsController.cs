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
    public class TeamsController : ControllerBase
    {
        private readonly ICommandHandler<CreateNewTeam> _createNewTeamHandler;
        private readonly IQueryHandler<GetTeam, TeamDto> _getTeamHandler;
        public TeamsController(ICommandHandler<CreateNewTeam> createNewTeamHandler,
            IQueryHandler<GetTeam, TeamDto> getTeamHandler)
        {
            _createNewTeamHandler = createNewTeamHandler ?? throw new ArgumentNullException(nameof(createNewTeamHandler));
            _getTeamHandler = getTeamHandler ?? throw new ArgumentNullException(nameof(getTeamHandler));
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewTeam(CreateNewTeam createNewTeam)
        {
            var newTeam = createNewTeam.TeamId == Guid.Empty 
                ? createNewTeam with { TeamId = Guid.NewGuid() } 
                : createNewTeam; 
            await _createNewTeamHandler.HandleAsync(newTeam);
            return Ok(newTeam.TeamId);
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll(Guid teamId)
        {
            return Ok(await _getTeamHandler.HandleAsync(new() { TeamId = teamId }));
        }
    }
}
