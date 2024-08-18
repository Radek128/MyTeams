using Microsoft.AspNetCore.Mvc;
using MySpot.Application.Abstractions;
using MyTeam.Application.Commands;

namespace MyTeam.Api.Controllers
{
    [ApiController]
    [Route("teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ICommandHandler<CreateNewTeam> _createNewTeamHandler;

        public TeamsController(ICommandHandler<CreateNewTeam> createNewTeamHandler)
        {
            _createNewTeamHandler = createNewTeamHandler;
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewTeam(CreateNewTeam createNewTeam)
        {
            var newTeam = createNewTeam.NewTeamId == Guid.Empty 
                ? createNewTeam with { NewTeamId = Guid.NewGuid() } 
                : createNewTeam; 
            await _createNewTeamHandler.HandleAsync(newTeam);
            return Ok(newTeam.NewTeamId);
        }
    }
}
