//////////////////////////////////////
// generated IOrderLineService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IOrderLineService
    {
        Task<string> AddOrderLine(OrderLine entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<OrderLine> entities, string Message)> FindOrderLine(Expression<Func<OrderLine, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<OrderLine> entities, string Message)> GetAllOrderLine(CancellationToken cancellationToken = default);
        Task<(OrderLine? entity, string Message)> GetOrderLineById(int? LineId, CancellationToken cancellationToken = default);
        Task<string> RemoveOrderLine(int? LineId, CancellationToken cancellationToken = default);
        Task<string> UpdateOrderLine(int? LineId, OrderLine entity, CancellationToken cancellationToken = default);
    }
}
