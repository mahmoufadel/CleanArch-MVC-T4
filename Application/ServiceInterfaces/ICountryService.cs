//////////////////////////////////////
// generated ICountryService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface ICountryService
    {
        Task<string> AddCountry(Country entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Country> entities, string Message)> FindCountry(Expression<Func<Country, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Country> entities, string Message)> GetAllCountry(CancellationToken cancellationToken = default);
        Task<(Country? entity, string Message)> GetCountryById(int? Id, CancellationToken cancellationToken = default);
        Task<string> RemoveCountry(int? Id, CancellationToken cancellationToken = default);
        Task<string> UpdateCountry(int? Id, Country entity, CancellationToken cancellationToken = default);
    }
}
