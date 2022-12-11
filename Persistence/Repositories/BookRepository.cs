////////////////////////////////////////
// generated BookRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Book?> GetById(int? BookId)
        {
            return await _context.Set<Book>().FindAsync(BookId);
        }
    }
}
