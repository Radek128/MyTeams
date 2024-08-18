namespace MyTeam.Domain.Exceptions
{
    public class InvalidFullNameException : BusinessException
    {
        public InvalidFullNameException(object Id) : base($"Cannot set: {Id}  as .")
        {
                
        }
    }
}
