/////////////////////////////////////
// generated CollectionTypeService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CollectionTypeService : ICollectionTypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CollectionTypeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<CollectionType> entities, string Message)> FindCollectionType(Expression<Func<CollectionType, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CollectionTypeRepository.Find(expression);
            return (items, "CollectionType records retrieved");
        }

        public async Task<(IEnumerable<CollectionType> entities, string Message)> GetAllCollectionType(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CollectionTypeRepository.GetAll();
            return (items, "CollectionType records retrieved");
        }

        public async Task<(CollectionType? entity, string Message)> GetCollectionTypeById(byte? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CollectionTypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("CollectionType", Id.ToString() );
            }
            return (item, "CollectionType record retrieved");
        }

        public async Task<string> AddCollectionType(CollectionType entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.CollectionTypeRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("CollectionType", entity.Id.ToString() );
                }
                else
                {
                    await _repositoryManager.CollectionTypeRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "CollectionType record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveCollectionType(byte? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CollectionTypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("CollectionType", Id.ToString() );
            }
            else
            {
                _repositoryManager.CollectionTypeRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "CollectionType record deleted";
            }
        }

        public async Task<string> UpdateCollectionType(byte? Id, CollectionType entity, CancellationToken cancellationToken = default)
        {
            if(!(Id == entity.Id))
            {
                throw new BadKeyException("CollectionType", entity.Id.ToString() , Id.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.CollectionTypeRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("CollectionType", Id.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "CollectionType record updated";
        }
    }
}
