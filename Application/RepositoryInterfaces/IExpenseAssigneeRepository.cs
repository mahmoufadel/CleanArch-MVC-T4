/////////////////////////////////////////
// generated IExpenseAssigneeRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IExpenseAssigneeRepository : IGenericRepository<ExpenseAssignee>
    {
        ValueTask<ExpenseAssignee?> GetById(int? Id);
    }
}
