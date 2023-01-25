////////////////////////////////////////
// generated CollectionTypeRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CollectionTypeRepository : GenericRepository<CollectionType>, ICollectionTypeRepository
    {
        public CollectionTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<CollectionType?> GetById(byte? Id)
        {
            return await _context.Set<CollectionType>().FindAsync(Id);
        }
    }
}
