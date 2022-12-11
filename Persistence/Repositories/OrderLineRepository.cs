////////////////////////////////////////
// generated OrderLineRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderLineRepository : GenericRepository<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<OrderLine?> GetById(int? LineId)
        {
            return await _context.Set<OrderLine>().FindAsync(LineId);
        }
    }
}
