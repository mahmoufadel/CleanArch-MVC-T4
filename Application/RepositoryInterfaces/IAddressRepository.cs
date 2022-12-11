/////////////////////////////////////////
// generated IAddressRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        ValueTask<Address?> GetById(int? AddressId);
    }
}
