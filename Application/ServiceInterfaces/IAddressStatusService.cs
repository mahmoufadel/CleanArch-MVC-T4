//////////////////////////////////////
// generated IAddressStatusService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IAddressStatusService
    {
        Task<string> AddAddressStatus(AddressStatus entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<AddressStatus> entities, string Message)> FindAddressStatus(Expression<Func<AddressStatus, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<AddressStatus> entities, string Message)> GetAllAddressStatus(CancellationToken cancellationToken = default);
        Task<(AddressStatus? entity, string Message)> GetAddressStatusById(int? StatusId, CancellationToken cancellationToken = default);
        Task<string> RemoveAddressStatus(int? StatusId, CancellationToken cancellationToken = default);
        Task<string> UpdateAddressStatus(int? StatusId, AddressStatus entity, CancellationToken cancellationToken = default);
    }
}
