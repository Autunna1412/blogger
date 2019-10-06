using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blogger.Core.Application.Ports.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        Task SaveChangesAsync();

        Task SaveChangesAsync(CancellationToken cancellationToken);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
