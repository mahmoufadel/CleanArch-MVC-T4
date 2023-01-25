////////////////////////////////////////
// generated CountryRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Country?> GetById(int? Id)
        {
            return await _context.Set<Country>().FindAsync(Id);
        }
    }
}
