/////////////////////////////////////////
// generated ICustomerRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        ValueTask<Customer?> GetById(int? CustomerId);
    }
}
