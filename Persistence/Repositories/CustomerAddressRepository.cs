////////////////////////////////////////
// generated CustomerAddressRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CustomerAddressRepository : GenericRepository<CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<CustomerAddress?> GetById(int? CustomerId,int? AddressId)
        {
            return await _context.Set<CustomerAddress>().FindAsync(CustomerId,AddressId);
        }
    }
}
