using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Application.Dto
{
    public record TeamDto(Guid TeamId, string  Name, IEnumerable<MemberDto> Members);
}
