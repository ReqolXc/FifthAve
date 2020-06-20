namespace FifthAve.Core.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public MongodbConfiguration Mongodb { get; set; }
    }

    public interface IAppConfiguration
    {
        MongodbConfiguration Mongodb { get; set; }
    }
}
