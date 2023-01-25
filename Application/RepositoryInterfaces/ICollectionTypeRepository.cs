/////////////////////////////////////////
// generated ICollectionTypeRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICollectionTypeRepository : IGenericRepository<CollectionType>
    {
        ValueTask<CollectionType?> GetById(byte? Id);
    }
}
