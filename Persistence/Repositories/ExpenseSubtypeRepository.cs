////////////////////////////////////////
// generated ExpenseSubtypeRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ExpenseSubtypeRepository : GenericRepository<ExpenseSubtype>, IExpenseSubtypeRepository
    {
        public ExpenseSubtypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<ExpenseSubtype?> GetById(int? Id)
        {
            return await _context.Set<ExpenseSubtype>().FindAsync(Id);
        }
    }
}
