using MyTeam.Application.Abstractions;
using MyTeam.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Application.Queries
{
    public class GetTeam : IQuery<TeamDto>
    {
        public Guid TeamId { get; set; }
    }
}
