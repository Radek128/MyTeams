using MyTeam.Domain.Exceptions;

namespace MyTeam.Domain.ValueObjects
{
    public record TeamName
    {
        public string Value { get; }

        public TeamName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 10 or < 2)
            {
                throw new InvalidFullNameException(value);
            }

            Value = value;
        }

        public static implicit operator TeamName(string value) => new TeamName(value);

        public static implicit operator string(TeamName value) => value.Value;

        public override string ToString() => Value;
    }
}
