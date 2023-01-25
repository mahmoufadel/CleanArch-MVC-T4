////////////////////////////////////////
// generated ValuetypeRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ValuetypeRepository : GenericRepository<Valuetype>, IValuetypeRepository
    {
        public ValuetypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Valuetype?> GetById(byte? Id)
        {
            return await _context.Set<Valuetype>().FindAsync(Id);
        }
    }
}
