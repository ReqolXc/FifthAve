using System.Threading;
using System.Threading.Tasks;
using FifthAve.Core.BaseEntities;
using MongoDB.Driver;

namespace FifthAve.Core.Database
{
    public class DatabaseSession : IDatabaseSession
    {
        private readonly IDatabaseProvider _databaseProvider;
        private readonly IClientSessionHandle _session;
        public DatabaseSession(IClientSessionHandle session, IDatabaseProvider databaseProvider)
        {
            _session = session;
            _databaseProvider = databaseProvider;
        }

        public void StartTransaction()
            => _session.StartTransaction();

        public Task AbortTransactionAsync(CancellationToken cancellationToken)
            => _session.AbortTransactionAsync(cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken) 
            => _session.CommitTransactionAsync(cancellationToken);

        public void Dispose() 
            => _session.Dispose();

        public IBaseRepository<T> GetRepository<T>() where T : IBaseEntity
            => new BaseSessionRepository<T>(_session, _databaseProvider);
    }
}