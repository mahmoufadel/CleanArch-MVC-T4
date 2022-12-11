/////////////////////////////////////////
// generated IAddressStatusRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IAddressStatusRepository : IGenericRepository<AddressStatus>
    {
        ValueTask<AddressStatus?> GetById(int? StatusId);
    }
}
