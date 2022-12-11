/////////////////////////////////////////
// generated IShippingMethodRepository.cs //
/////////////////////////////////////////
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IShippingMethodRepository : IGenericRepository<ShippingMethod>
    {
        ValueTask<ShippingMethod?> GetById(int? MethodId);
    }
}
