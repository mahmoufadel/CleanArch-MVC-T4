/////////////////////////////////////////
// generated IExpenseRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
        ValueTask<Expense?> GetById(int? Id);
    }
}
