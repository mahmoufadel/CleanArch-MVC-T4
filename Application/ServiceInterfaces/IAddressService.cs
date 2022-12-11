//////////////////////////////////////
// generated IAddressService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IAddressService
    {
        Task<string> AddAddress(Address entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Address> entities, string Message)> FindAddress(Expression<Func<Address, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Address> entities, string Message)> GetAllAddress(CancellationToken cancellationToken = default);
        Task<(Address? entity, string Message)> GetAddressById(int? AddressId, CancellationToken cancellationToken = default);
        Task<string> RemoveAddress(int? AddressId, CancellationToken cancellationToken = default);
        Task<string> UpdateAddress(int? AddressId, Address entity, CancellationToken cancellationToken = default);
    }
}
