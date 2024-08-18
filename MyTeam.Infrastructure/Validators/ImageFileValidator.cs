using MyTeam.Application.Abstractions;

namespace MyTeam.Infrastructure.Validators
{
    public class ImageFileValidator : IFileValidator
    {
        private readonly HashSet<string> _fileExtensions = [".jpg"];
        public void Validate(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
