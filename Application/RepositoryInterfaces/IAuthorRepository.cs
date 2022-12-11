/////////////////////////////////////////
// generated IAuthorRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        ValueTask<Author?> GetById(int? AuthorId);
    }
}
