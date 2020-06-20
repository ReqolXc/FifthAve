using System.Threading;
using System.Threading.Tasks;

namespace FifthAve.Core.Database
{
    public interface IDatabaseSessionProvider
    {
        Task<DatabaseSession> StartSession(CancellationToken cancellationToken);
    }
}
