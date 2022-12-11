////////////////////////////////////////
// generated AddressRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Address?> GetById(int? AddressId)
        {
            return await _context.Set<Address>().FindAsync(AddressId);
        }
    }
}
