namespace apiautos.Data.Configuration
{
    public class AutomovilesDatabaseSettings : IAutosSettings
    {
        public string AutosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAutosSettings
    {
        string AutosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}