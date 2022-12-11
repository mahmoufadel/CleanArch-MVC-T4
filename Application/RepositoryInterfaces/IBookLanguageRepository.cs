/////////////////////////////////////////
// generated IBookLanguageRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IBookLanguageRepository : IGenericRepository<BookLanguage>
    {
        ValueTask<BookLanguage?> GetById(int? LanguageId);
    }
}
