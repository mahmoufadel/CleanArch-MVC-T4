////////////////////////////////////////
// generated OrderHistoryRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderHistoryRepository : GenericRepository<OrderHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<OrderHistory?> GetById(int? HistoryId)
        {
            return await _context.Set<OrderHistory>().FindAsync(HistoryId);
        }
    }
}
