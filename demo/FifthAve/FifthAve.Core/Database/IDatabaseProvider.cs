using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FifthAve.Core.Database
{
    public interface IDatabaseProvider
    {
        Task<IClientSessionHandle> StartSessionAsync(ClientSessionOptions? clientSessionOptions = null, CancellationToken cancellationToken = default);
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>(string? collectionName = null);
    }
}
