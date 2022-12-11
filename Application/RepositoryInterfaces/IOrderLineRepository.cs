/////////////////////////////////////////
// generated IOrderLineRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IOrderLineRepository : IGenericRepository<OrderLine>
    {
        ValueTask<OrderLine?> GetById(int? LineId);
    }
}
