////////////////////////////////////////
// generated ExpenseAssigneeRepository.cs //
////////////////////////////////////////
using Application.RepositoryInterfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ExpenseAssigneeRepository : GenericRepository<ExpenseAssignee>, IExpenseAssigneeRepository
    {
        public ExpenseAssigneeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async ValueTask<ExpenseAssignee?> GetById(int? Id)
        {
            return await _context.Set<ExpenseAssignee>().FindAsync(Id);
        }
    }
}
