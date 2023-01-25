/////////////////////////////////////////
// generated IExpenseSubtypeRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IExpenseSubtypeRepository : IGenericRepository<ExpenseSubtype>
    {
        ValueTask<ExpenseSubtype?> GetById(int? Id);
    }
}
