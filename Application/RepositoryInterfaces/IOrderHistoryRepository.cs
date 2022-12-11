/////////////////////////////////////////
// generated IOrderHistoryRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IOrderHistoryRepository : IGenericRepository<OrderHistory>
    {
        ValueTask<OrderHistory?> GetById(int? HistoryId);
    }
}
