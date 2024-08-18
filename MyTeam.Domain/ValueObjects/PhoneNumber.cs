using MyTeam.Domain.Exceptions;

namespace MyTeam.Domain.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 14 or < 4)
            {
                throw new InvalidFullNameException(value);
            }

            Value = value;
        }

        public static implicit operator PhoneNumber(string value) => new PhoneNumber(value);

        public static implicit operator string(PhoneNumber value) => value.Value;

        public override string ToString() => Value;
    }
}
