using MyTeam.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Domain.ValueObjects
{
    public record FullName
    {
        public string Value { get; }

        public FullName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 50 or < 2)
            {
                throw new InvalidFullNameException(value);
            }

            Value = value;
        }

        public static implicit operator FullName(string value) => new FullName(value);

        public static implicit operator string(FullName value) => value.Value;

        public override string ToString() => Value;
    }
}
