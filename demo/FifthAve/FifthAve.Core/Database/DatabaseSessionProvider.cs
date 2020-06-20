using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FifthAve.Core.Database
{
    public class DatabaseSessionProvider : IDatabaseSessionProvider
    {
        private readonly IDatabaseProvider _databaseProvider;
        private IClientSessionHandle? _session;

        public DatabaseSessionProvider(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<DatabaseSession> StartSession(CancellationToken cancellationToken)
        {
            _session = await _databaseProvider.StartSessionAsync(cancellationToken: cancellationToken);
            return new DatabaseSession(_session, _databaseProvider);
        }
    }
}
