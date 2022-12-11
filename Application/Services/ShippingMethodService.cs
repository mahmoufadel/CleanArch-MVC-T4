/////////////////////////////////////
// generated ShippingMethodService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ShippingMethodService : IShippingMethodService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ShippingMethodService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<ShippingMethod> entities, string Message)> FindShippingMethod(Expression<Func<ShippingMethod, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ShippingMethodRepository.Find(expression);
            return (items, "ShippingMethod records retrieved");
        }

        public async Task<(IEnumerable<ShippingMethod> entities, string Message)> GetAllShippingMethod(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ShippingMethodRepository.GetAll();
            return (items, "ShippingMethod records retrieved");
        }

        public async Task<(ShippingMethod? entity, string Message)> GetShippingMethodById(int? MethodId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ShippingMethodRepository.GetById(MethodId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ShippingMethod", MethodId.ToString() );
            }
            return (item, "ShippingMethod record retrieved");
        }

        public async Task<string> AddShippingMethod(ShippingMethod entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.ShippingMethodRepository.GetById(entity.MethodId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("ShippingMethod", entity.MethodId.ToString() );
                }
                else
                {
                    await _repositoryManager.ShippingMethodRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "ShippingMethod record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveShippingMethod(int? MethodId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ShippingMethodRepository.GetById(MethodId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ShippingMethod", MethodId.ToString() );
            }
            else
            {
                _repositoryManager.ShippingMethodRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "ShippingMethod record deleted";
            }
        }

        public async Task<string> UpdateShippingMethod(int? MethodId, ShippingMethod entity, CancellationToken cancellationToken = default)
        {
            if(!(MethodId == entity.MethodId))
            {
                throw new BadKeyException("ShippingMethod", entity.MethodId.ToString() , MethodId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.ShippingMethodRepository.GetById(MethodId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("ShippingMethod", MethodId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "ShippingMethod record updated";
        }
    }
}
