using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Domain.Exceptions
{
    internal class TeamNameAlreadyInUseException : BusinessException
    {
        public TeamNameAlreadyInUseException(string message) : base(message)
        {
        }
    }
}
