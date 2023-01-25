//////////////////////////////////////
// generated IExpenseAssigneeService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IExpenseAssigneeService
    {
        Task<string> AddExpenseAssignee(ExpenseAssignee entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ExpenseAssignee> entities, string Message)> FindExpenseAssignee(Expression<Func<ExpenseAssignee, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ExpenseAssignee> entities, string Message)> GetAllExpenseAssignee(CancellationToken cancellationToken = default);
        Task<(ExpenseAssignee? entity, string Message)> GetExpenseAssigneeById(int? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveExpenseAssignee(int? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateExpenseAssignee(int? Id, ExpenseAssignee entity, CancellationToken cancellationToken = default);
    }
}
