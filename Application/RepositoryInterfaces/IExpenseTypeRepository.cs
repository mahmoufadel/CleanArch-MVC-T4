/////////////////////////////////////////
// generated IExpenseTypeRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IExpenseTypeRepository : IGenericRepository<ExpenseType>
    {
        ValueTask<ExpenseType?> GetById(byte? Id);
    }
}
