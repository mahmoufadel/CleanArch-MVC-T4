/////////////////////////////////////////
// generated IValuetypeRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IValuetypeRepository : IGenericRepository<Valuetype>
    {
        ValueTask<Valuetype?> GetById(byte? Id);
    }
}
