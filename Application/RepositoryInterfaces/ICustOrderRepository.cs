/////////////////////////////////////////
// generated ICustOrderRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICustOrderRepository : IGenericRepository<CustOrder>
    {
        ValueTask<CustOrder?> GetById(int? OrderId);
    }
}
