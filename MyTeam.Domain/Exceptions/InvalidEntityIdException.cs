namespace MyTeam.Domain.Exceptions
{
    public class InvalidEntityIdException : BusinessException
    {
        public InvalidEntityIdException(object Id) : base($"Cannot set: {Id}  as id.")
        {

        }
    }
}
