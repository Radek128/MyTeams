using MyTeam.Domain.Exceptions;

namespace MyTeam.Domain.ValueObjects
{
    public record MemberId
    {
        public Guid Value { get; }

        public MemberId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(MemberId value) => value.Value;

        public static implicit operator MemberId(Guid value) => new(value);
    }
}
