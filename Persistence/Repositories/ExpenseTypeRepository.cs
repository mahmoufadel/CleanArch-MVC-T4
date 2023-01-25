////////////////////////////////////////
// generated ExpenseTypeRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ExpenseTypeRepository : GenericRepository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<ExpenseType?> GetById(byte? Id)
        {
            return await _context.Set<ExpenseType>().FindAsync(Id);
        }
    }
}
