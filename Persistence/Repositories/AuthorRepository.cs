////////////////////////////////////////
// generated AuthorRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Author?> GetById(int? AuthorId)
        {
            return await _context.Set<Author>().FindAsync(AuthorId);
        }
    }
}
