namespace MyTeam.Domain.Exceptions
{
    public class MemberAlreadyExistsException : BusinessException
    {
        public MemberAlreadyExistsException(string name, string fullName) : base($"Member: {name} {fullName} already exists .")
        {

        }
    }
}
