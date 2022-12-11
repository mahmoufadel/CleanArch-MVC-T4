//////////////////////////////////////
// generated IShippingMethodService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IShippingMethodService
    {
        Task<string> AddShippingMethod(ShippingMethod entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ShippingMethod> entities, string Message)> FindShippingMethod(Expression<Func<ShippingMethod, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ShippingMethod> entities, string Message)> GetAllShippingMethod(CancellationToken cancellationToken = default);
        Task<(ShippingMethod? entity, string Message)> GetShippingMethodById(int? MethodId, CancellationToken cancellationToken = default);
        Task<string> RemoveShippingMethod(int? MethodId, CancellationToken cancellationToken = default);
        Task<string> UpdateShippingMethod(int? MethodId, ShippingMethod entity, CancellationToken cancellationToken = default);
    }
}
