//////////////////////////////////////
// generated IOrderStatusService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IOrderStatusService
    {
        Task<string> AddOrderStatus(OrderStatus entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<OrderStatus> entities, string Message)> FindOrderStatus(Expression<Func<OrderStatus, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<OrderStatus> entities, string Message)> GetAllOrderStatus(CancellationToken cancellationToken = default);
        Task<(OrderStatus? entity, string Message)> GetOrderStatusById(int? StatusId, CancellationToken cancellationToken = default);
        Task<string> RemoveOrderStatus(int? StatusId, CancellationToken cancellationToken = default);
        Task<string> UpdateOrderStatus(int? StatusId, OrderStatus entity, CancellationToken cancellationToken = default);
    }
}
