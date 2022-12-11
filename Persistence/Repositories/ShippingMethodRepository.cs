////////////////////////////////////////
// generated ShippingMethodRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ShippingMethodRepository : GenericRepository<ShippingMethod>, IShippingMethodRepository
    {
        public ShippingMethodRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<ShippingMethod?> GetById(int? MethodId)
        {
            return await _context.Set<ShippingMethod>().FindAsync(MethodId);
        }
    }
}
