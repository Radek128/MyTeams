using MyTeam.Domain.ValueObjects;

namespace MyTeam.Application.Abstractions
{
    public interface IFileService
    {
        Task<FileInformation> SaveFile(Stream stream);
        Task<FileStream> GetFileAsync(string fileName);
        Task DeleteFile(string fileName);
    }
}
