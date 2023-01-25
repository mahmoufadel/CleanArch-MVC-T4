//////////////////////////////////////
// generated IValuetypeService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IValuetypeService
    {
        Task<string> AddValuetype(Valuetype entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Valuetype> entities, string Message)> FindValuetype(Expression<Func<Valuetype, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Valuetype> entities, string Message)> GetAllValuetype(CancellationToken cancellationToken = default);
        Task<(Valuetype? entity, string Message)> GetValuetypeById(byte? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveValuetype(byte? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateValuetype(byte? Id, Valuetype entity, CancellationToken cancellationToken = default);
    }
}
