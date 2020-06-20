using FifthAve.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace FifthAve.Core.Database
{
    public static class DatabaseModule
    {
        public static IServiceCollection AddTo(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(provider =>
            {
                var config = provider.GetService<IAppConfiguration>();
                return new MongoClient(string.Concat("mongodb://", config.Mongodb.Host));
            });

            services.AddSingleton<IDatabaseProvider>(provider =>
            {
                var config = provider.GetService<IAppConfiguration>();
                var client = provider.GetService<IMongoClient>();
                return new DatabaseProvider(client, config.Mongodb.DbName!);
            });

            services.AddSingleton<IDatabaseSessionProvider>(provider =>
            {
                var dbProvider = provider.GetService<IDatabaseProvider>();
                return new DatabaseSessionProvider(dbProvider);
            });

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            return services;
        }
    }
}
