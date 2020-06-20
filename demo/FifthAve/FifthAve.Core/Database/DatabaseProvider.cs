using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FifthAve.Core.Database
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly IMongoClient _client;
        public readonly string DbName;

        public DatabaseProvider(IMongoClient client, string dbName)
        {
            DbName = dbName;
            _client = client;
        }

        public Task<IClientSessionHandle> StartSessionAsync(ClientSessionOptions? clientSessionOptions = null, CancellationToken cancellationToken = default)
            => _client.StartSessionAsync(clientSessionOptions, cancellationToken);

        public IMongoDatabase GetDatabase()
            => _client.GetDatabase(DbName);

        public IMongoCollection<T> GetCollection<T>(string? collectionName = null)
            => _client.GetDatabase(DbName).GetCollection<T>(collectionName ?? typeof(T).Name);
    }
}
