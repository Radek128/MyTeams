namespace MyTeam.Domain.ValueObjects
{
    public record FileInformation
    {
        public string Path { get; }
        public FileInformation(string path)
        {
            Path = path;
        }

        public static implicit operator FileInformation(string value) => new FileInformation(value);

        public static implicit operator string(FileInformation value) => value.Path;

        public override string ToString() => Path;
    }
}
