/////////////////////////////////////
// generated ValuetypeService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ValuetypeService : IValuetypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ValuetypeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Valuetype> entities, string Message)> FindValuetype(Expression<Func<Valuetype, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ValuetypeRepository.Find(expression);
            return (items, "Valuetype records retrieved");
        }

        public async Task<(IEnumerable<Valuetype> entities, string Message)> GetAllValuetype(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ValuetypeRepository.GetAll();
            return (items, "Valuetype records retrieved");
        }

        public async Task<(Valuetype? entity, string Message)> GetValuetypeById(byte? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ValuetypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Valuetype", Id.ToString() );
            }
            return (item, "Valuetype record retrieved");
        }

        public async Task<string> AddValuetype(Valuetype entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.ValuetypeRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Valuetype", entity.Id.ToString() );
                }
                else
                {
                    await _repositoryManager.ValuetypeRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Valuetype record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveValuetype(byte? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ValuetypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Valuetype", Id.ToString() );
            }
            else
            {
                _repositoryManager.ValuetypeRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Valuetype record deleted";
            }
        }

        public async Task<string> UpdateValuetype(byte? Id, Valuetype entity, CancellationToken cancellationToken = default)
        {
            if(!(Id == entity.Id))
            {
                throw new BadKeyException("Valuetype", entity.Id.ToString() , Id.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.ValuetypeRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Valuetype", Id.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Valuetype record updated";
        }
    }
}
