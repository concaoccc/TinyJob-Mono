namespace TinyJobApi.Config
{
    public class DatabaseOption
    {
        public const string SectionName = "Database";
        public string ConnectionString { get; set; } = string.Empty;
    }
}