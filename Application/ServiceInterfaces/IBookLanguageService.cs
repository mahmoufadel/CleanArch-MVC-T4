//////////////////////////////////////
// generated IBookLanguageService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface IBookLanguageService
    {
        Task<string> AddBookLanguage(BookLanguage entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<BookLanguage> entities, string Message)> FindBookLanguage(Expression<Func<BookLanguage, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<BookLanguage> entities, string Message)> GetAllBookLanguage(CancellationToken cancellationToken = default);
        Task<(BookLanguage? entity, string Message)> GetBookLanguageById(int? LanguageId, CancellationToken cancellationToken = default);
        Task<string> RemoveBookLanguage(int? LanguageId, CancellationToken cancellationToken = default);
        Task<string> UpdateBookLanguage(int? LanguageId, BookLanguage entity, CancellationToken cancellationToken = default);
    }
}
