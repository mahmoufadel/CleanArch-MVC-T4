////////////////////////////////////////
// generated SampleRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class SampleRepository : GenericRepository<Sample>, ISampleRepository
    {
        public SampleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Sample?> GetById(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3)
        {
            return await _context.Set<Sample>().FindAsync(Id1, Id2, Id3);
        }
    }
}
