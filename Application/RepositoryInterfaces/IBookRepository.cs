/////////////////////////////////////////
// generated IBookRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        ValueTask<Book?> GetById(int? BookId);
    }
}
