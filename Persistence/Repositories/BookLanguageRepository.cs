////////////////////////////////////////
// generated BookLanguageRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class BookLanguageRepository : GenericRepository<BookLanguage>, IBookLanguageRepository
    {
        public BookLanguageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<BookLanguage?> GetById(int? LanguageId)
        {
            return await _context.Set<BookLanguage>().FindAsync(LanguageId);
        }
    }
}
