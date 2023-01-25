/////////////////////////////////////////
// generated ICustomerAddressRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICustomerAddressRepository : IGenericRepository<CustomerAddress>
    {
        ValueTask<CustomerAddress?> GetById(int? CustomerId, int? AddressId);
    }
}
