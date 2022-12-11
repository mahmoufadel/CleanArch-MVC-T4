/////////////////////////////////////////
// generated ISampleRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface ISampleRepository : IGenericRepository<Sample>
    {
        ValueTask<Sample?> GetById(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3);
    }
}
