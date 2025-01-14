namespace MyTeam.Domain.Exceptions
{
    public class InvalidFullNameException : BusinessException
    {
        public InvalidFullNameException(object Id) : base($"Invalid name: {Id}.")
        {
                
        }
    }
}
