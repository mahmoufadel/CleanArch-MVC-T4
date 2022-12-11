////////////////////////////////////////
// generated AddressStatusRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AddressStatusRepository : GenericRepository<AddressStatus>, IAddressStatusRepository
    {
        public AddressStatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<AddressStatus?> GetById(int? StatusId)
        {
            return await _context.Set<AddressStatus>().FindAsync(StatusId);
        }
    }
}
