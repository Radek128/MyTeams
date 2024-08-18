using MyTeam.Application.Abstractions;
using MyTeam.Domain.ValueObjects;

namespace MyTeam.Infrastructure.FileStorage
{
    public class LocalStorageFileService : IFileService
    {
        private readonly string _fileStorageAddres;

        public LocalStorageFileService()
        {
            _fileStorageAddres = Path.Combine(Directory.GetCurrentDirectory(), "files");
        }

        public Task DeleteFile(string fileName)
        {
            string tempFilePath = GetDestinationPath(fileName);
            if (!Directory.Exists(tempFilePath))
            {
                Directory.Delete(tempFilePath);
            }
            return Task.CompletedTask;
        }

        public Task<FileStream> GetFileAsync(string fileName)
        {
            string tempFilePath = GetDestinationPath(fileName);
            return Task.FromResult(File.OpenRead(tempFilePath));
        }

        public async Task<FileInformation> SaveFile(Stream stream)
        {
            if (!Directory.Exists(_fileStorageAddres))
            {
                Directory.CreateDirectory(_fileStorageAddres);
            }
            string fileName = $"{Guid.NewGuid()}.jpg";
            string tempFilePath = GetDestinationPath(fileName);
            using FileStream streamToWrite = File.OpenWrite(tempFilePath);
            await stream.CopyToAsync(streamToWrite);
            return new FileInformation(fileName);
        }

        private string GetDestinationPath(string fileName)
        {
            return Path.Combine(_fileStorageAddres, fileName);
        }
    }
}
