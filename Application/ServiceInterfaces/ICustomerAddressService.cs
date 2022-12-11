//////////////////////////////////////
// generated ICustomerAddressService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface ICustomerAddressService
    {
        Task<string> AddCustomerAddress(CustomerAddress entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<CustomerAddress> entities, string Message)> FindCustomerAddress(Expression<Func<CustomerAddress, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<CustomerAddress> entities, string Message)> GetAllCustomerAddress(CancellationToken cancellationToken = default);
        Task<(CustomerAddress? entity, string Message)> GetCustomerAddressById(int? CustomerId,int? AddressId, CancellationToken cancellationToken = default);
        Task<string> RemoveCustomerAddress(int? CustomerId,int? AddressId, CancellationToken cancellationToken = default);
        Task<string> UpdateCustomerAddress(int? CustomerId,int? AddressId, CustomerAddress entity, CancellationToken cancellationToken = default);
    }
}
