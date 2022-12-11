////////////////////////////////////////
// generated CustOrderRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CustOrderRepository : GenericRepository<CustOrder>, ICustOrderRepository
    {
        public CustOrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<CustOrder?> GetById(int? OrderId)
        {
            return await _context.Set<CustOrder>().FindAsync(OrderId);
        }
    }
}
