////////////////////////////////////////
// generated CustomerRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Customer?> GetById(int? CustomerId)
        {
            return await _context.Set<Customer>().FindAsync(CustomerId);
        }
    }
}
