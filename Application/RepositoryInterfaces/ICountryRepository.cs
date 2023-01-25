/////////////////////////////////////////
// generated ICountryRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        ValueTask<Country?> GetById(int? Id);
    }
}
