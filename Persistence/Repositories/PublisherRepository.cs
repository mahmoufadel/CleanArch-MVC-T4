////////////////////////////////////////
// generated PublisherRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Publisher?> GetById(int? PublisherId)
        {
            return await _context.Set<Publisher>().FindAsync(PublisherId);
        }
    }
}
