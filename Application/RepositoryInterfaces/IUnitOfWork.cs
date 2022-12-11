//////////////////////////////
// generated IUnitOfWork.cs //
//////////////////////////////
using Microsoft.EntityFrameworkCore;

namespace Application.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        DbContext GetContext();
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
