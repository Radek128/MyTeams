namespace MyTeam.Domain.Exceptions
{
    public class InvalidEmailException : BusinessException
    {
        public InvalidEmailException(string message) : base(message)
        {
            
        }
    }
}
