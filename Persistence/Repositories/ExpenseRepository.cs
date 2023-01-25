////////////////////////////////////////
// generated ExpenseRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<Expense?> GetById(int? Id)
        {
            return await _context.Set<Expense>().FindAsync(Id);
        }
    }
}
