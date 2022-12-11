/////////////////////////////////////////
// generated IOrderStatusRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IOrderStatusRepository : IGenericRepository<OrderStatus>
    {
        ValueTask<OrderStatus?> GetById(int? StatusId);
    }
}
