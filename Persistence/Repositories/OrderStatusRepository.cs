////////////////////////////////////////
// generated OrderStatusRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<OrderStatus?> GetById(int? StatusId)
        {
            return await _context.Set<OrderStatus>().FindAsync(StatusId);
        }
    }
}
