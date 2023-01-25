//////////////////////////////////////
// generated ICollectionTypeService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface ICollectionTypeService
    {
        Task<string> AddCollectionType(CollectionType entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<CollectionType> entities, string Message)> FindCollectionType(Expression<Func<CollectionType, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<CollectionType> entities, string Message)> GetAllCollectionType(CancellationToken cancellationToken = default);
        Task<(CollectionType? entity, string Message)> GetCollectionTypeById(byte? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveCollectionType(byte? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateCollectionType(byte? Id, CollectionType entity, CancellationToken cancellationToken = default);
    }
}
