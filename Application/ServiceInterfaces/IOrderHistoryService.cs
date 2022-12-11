//////////////////////////////////////
// generated IOrderHistoryService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IOrderHistoryService
    {
        Task<string> AddOrderHistory(OrderHistory entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<OrderHistory> entities, string Message)> FindOrderHistory(Expression<Func<OrderHistory, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<OrderHistory> entities, string Message)> GetAllOrderHistory(CancellationToken cancellationToken = default);
        Task<(OrderHistory? entity, string Message)> GetOrderHistoryById(int? HistoryId, CancellationToken cancellationToken = default);
        Task<string> RemoveOrderHistory(int? HistoryId, CancellationToken cancellationToken = default);
        Task<string> UpdateOrderHistory(int? HistoryId, OrderHistory entity, CancellationToken cancellationToken = default);
    }
}
