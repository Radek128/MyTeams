using MyTeam.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Domain.ValueObjects
{
    public sealed record TeamId
    {
        public Guid Value { get; }

        public TeamId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(TeamId value) => value.Value;

        public static implicit operator TeamId(Guid value) => new(value);
    }
}
