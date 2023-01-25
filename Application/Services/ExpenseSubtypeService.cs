/////////////////////////////////////
// generated ExpenseSubtypeService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ExpenseSubtypeService : IExpenseSubtypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ExpenseSubtypeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<ExpenseSubtype> entities, string Message)> FindExpenseSubtype(Expression<Func<ExpenseSubtype, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseSubtypeRepository.Find(expression);
            return (items, "ExpenseSubtype records retrieved");
        }

        public async Task<(IEnumerable<ExpenseSubtype> entities, string Message)> GetAllExpenseSubtype(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseSubtypeRepository.GetAll();
            return (items, "ExpenseSubtype records retrieved");
        }

        public async Task<(ExpenseSubtype? entity, string Message)> GetExpenseSubtypeById(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseSubtypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ExpenseSubtype", Id.ToString() );
            }
            return (item, "ExpenseSubtype record retrieved");
        }

        public async Task<string> AddExpenseSubtype(ExpenseSubtype entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.ExpenseSubtypeRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("ExpenseSubtype", entity.Id.ToString() );
                }
                else
                {
                    await _repositoryManager.ExpenseSubtypeRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "ExpenseSubtype record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveExpenseSubtype(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseSubtypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ExpenseSubtype", Id.ToString() );
            }
            else
            {
                _repositoryManager.ExpenseSubtypeRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "ExpenseSubtype record deleted";
            }
        }

        public async Task<string> UpdateExpenseSubtype(int? Id, ExpenseSubtype entity, CancellationToken cancellationToken = default)
        {
            if(!(Id == entity.Id))
            {
                throw new BadKeyException("ExpenseSubtype", entity.Id.ToString() , Id.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.ExpenseSubtypeRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("ExpenseSubtype", Id.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "ExpenseSubtype record updated";
        }
    }
}
