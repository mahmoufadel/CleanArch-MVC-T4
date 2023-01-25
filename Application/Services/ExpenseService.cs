/////////////////////////////////////
// generated ExpenseService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ExpenseService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Expense> entities, string Message)> FindExpense(Expression<Func<Expense, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseRepository.Find(expression);
            return (items, "Expense records retrieved");
        }

        public async Task<(IEnumerable<Expense> entities, string Message)> GetAllExpense(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseRepository.GetAll();
            return (items, "Expense records retrieved");
        }

        public async Task<(Expense? entity, string Message)> GetExpenseById(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Expense", Id.ToString() );
            }
            return (item, "Expense record retrieved");
        }

        public async Task<string> AddExpense(Expense entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.ExpenseRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Expense", entity.Id.ToString() );
                }
                else
                {
                    await _repositoryManager.ExpenseRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Expense record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveExpense(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Expense", Id.ToString() );
            }
            else
            {
                _repositoryManager.ExpenseRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Expense record deleted";
            }
        }

        public async Task<string> UpdateExpense(int? Id, Expense entity, CancellationToken cancellationToken = default)
        {
            if(!(Id == entity.Id))
            {
                throw new BadKeyException("Expense", entity.Id.ToString() , Id.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.ExpenseRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Expense", Id.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Expense record updated";
        }
    }
}
