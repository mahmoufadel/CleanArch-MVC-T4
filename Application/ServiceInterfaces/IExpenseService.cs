//////////////////////////////////////
// generated IExpenseService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IExpenseService
    {
        Task<string> AddExpense(Expense entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Expense> entities, string Message)> FindExpense(Expression<Func<Expense, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Expense> entities, string Message)> GetAllExpense(CancellationToken cancellationToken = default);
        Task<(Expense? entity, string Message)> GetExpenseById(int? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveExpense(int? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateExpense(int? Id, Expense entity, CancellationToken cancellationToken = default);
    }
}
