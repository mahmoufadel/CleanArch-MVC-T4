//////////////////////////////////////
// generated IExpenseTypeService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IExpenseTypeService
    {
        Task<string> AddExpenseType(ExpenseType entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ExpenseType> entities, string Message)> FindExpenseType(Expression<Func<ExpenseType, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ExpenseType> entities, string Message)> GetAllExpenseType(CancellationToken cancellationToken = default);
        Task<(ExpenseType? entity, string Message)> GetExpenseTypeById(byte? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveExpenseType(byte? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateExpenseType(byte? Id, ExpenseType entity, CancellationToken cancellationToken = default);
    }
}
