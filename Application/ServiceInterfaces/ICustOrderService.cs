//////////////////////////////////////
// generated ICustOrderService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface ICustOrderService
    {
        Task<string> AddCustOrder(CustOrder entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<CustOrder> entities, string Message)> FindCustOrder(Expression<Func<CustOrder, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<CustOrder> entities, string Message)> GetAllCustOrder(CancellationToken cancellationToken = default);
        Task<(CustOrder? entity, string Message)> GetCustOrderById(int? OrderId, CancellationToken cancellationToken = default);
        Task<string> RemoveCustOrder(int? OrderId, CancellationToken cancellationToken = default);
        Task<string> UpdateCustOrder(int? OrderId, CustOrder entity, CancellationToken cancellationToken = default);
    }
}
