//////////////////////////////////////
// generated IExpenseSubtypeService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IExpenseSubtypeService
    {
        Task<string> AddExpenseSubtype(ExpenseSubtype entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ExpenseSubtype> entities, string Message)> FindExpenseSubtype(Expression<Func<ExpenseSubtype, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ExpenseSubtype> entities, string Message)> GetAllExpenseSubtype(CancellationToken cancellationToken = default);
        Task<(ExpenseSubtype? entity, string Message)> GetExpenseSubtypeById(int? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveExpenseSubtype(int? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateExpenseSubtype(int? Id, ExpenseSubtype entity, CancellationToken cancellationToken = default);
    }
}
