/////////////////////////////////////
// generated ExpenseTypeService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ExpenseTypeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<ExpenseType> entities, string Message)> FindExpenseType(Expression<Func<ExpenseType, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseTypeRepository.Find(expression);
            return (items, "ExpenseType records retrieved");
        }

        public async Task<(IEnumerable<ExpenseType> entities, string Message)> GetAllExpenseType(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseTypeRepository.GetAll();
            return (items, "ExpenseType records retrieved");
        }

        public async Task<(ExpenseType? entity, string Message)> GetExpenseTypeById(byte? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseTypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ExpenseType", Id.ToString() );
            }
            return (item, "ExpenseType record retrieved");
        }

        public async Task<string> AddExpenseType(ExpenseType entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.ExpenseTypeRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("ExpenseType", entity.Id.ToString() );
                }
                else
                {
                    await _repositoryManager.ExpenseTypeRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "ExpenseType record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveExpenseType(byte? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseTypeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ExpenseType", Id.ToString() );
            }
            else
            {
                _repositoryManager.ExpenseTypeRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "ExpenseType record deleted";
            }
        }

        public async Task<string> UpdateExpenseType(byte? Id, ExpenseType entity, CancellationToken cancellationToken = default)
        {
            if(!(Id == entity.Id))
            {
                throw new BadKeyException("ExpenseType", entity.Id.ToString() , Id.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.ExpenseTypeRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("ExpenseType", Id.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "ExpenseType record updated";
        }
    }
}
