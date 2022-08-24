namespace FirstWebAPIProject.Settings
{
    public class MongoDbSettings
    {
        public string? Host { get; set; }
        public string? Port { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}
