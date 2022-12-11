//////////////////////////////////////
// generated ICustomerService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<string> AddCustomer(Customer entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Customer> entities, string Message)> FindCustomer(Expression<Func<Customer, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Customer> entities, string Message)> GetAllCustomer(CancellationToken cancellationToken = default);
        Task<(Customer? entity, string Message)> GetCustomerById(int? CustomerId, CancellationToken cancellationToken = default);
        Task<string> RemoveCustomer(int? CustomerId, CancellationToken cancellationToken = default);
        Task<string> UpdateCustomer(int? CustomerId, Customer entity, CancellationToken cancellationToken = default);
    }
}
