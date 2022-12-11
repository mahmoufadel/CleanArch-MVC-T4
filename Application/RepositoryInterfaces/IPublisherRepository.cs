/////////////////////////////////////////
// generated IPublisherRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        ValueTask<Publisher?> GetById(int? PublisherId);
    }
}
