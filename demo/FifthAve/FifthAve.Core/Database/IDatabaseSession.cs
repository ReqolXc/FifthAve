using System;
using System.Threading;
using System.Threading.Tasks;
using FifthAve.Core.BaseEntities;

namespace FifthAve.Core.Database
{
    public interface IDatabaseSession : IDisposable
    {
        public void StartTransaction();

        public Task AbortTransactionAsync(CancellationToken cancellationToken);

        public Task CommitTransactionAsync(CancellationToken cancellationToken);

        public IBaseRepository<T> GetRepository<T>() where T : IBaseEntity;
    }
}