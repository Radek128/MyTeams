namespace MyTeam.Domain.Exceptions
{
    internal class TeamNameAlreadyInUseException : BusinessException
    {
        public TeamNameAlreadyInUseException(string message) : base(message)
        {
        }
    }
}
