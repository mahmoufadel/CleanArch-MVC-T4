/////////////////////////////////////
// generated ExpenseAssigneeService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ExpenseAssigneeService : IExpenseAssigneeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ExpenseAssigneeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<ExpenseAssignee> entities, string Message)> FindExpenseAssignee(Expression<Func<ExpenseAssignee, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseAssigneeRepository.Find(expression);
            return (items, "ExpenseAssignee records retrieved");
        }

        public async Task<(IEnumerable<ExpenseAssignee> entities, string Message)> GetAllExpenseAssignee(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ExpenseAssigneeRepository.GetAll();
            return (items, "ExpenseAssignee records retrieved");
        }

        public async Task<(ExpenseAssignee? entity, string Message)> GetExpenseAssigneeById(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseAssigneeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ExpenseAssignee", Id.ToString() );
            }
            return (item, "ExpenseAssignee record retrieved");
        }

        public async Task<string> AddExpenseAssignee(ExpenseAssignee entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.ExpenseAssigneeRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("ExpenseAssignee", entity.Id.ToString() );
                }
                else
                {
                    await _repositoryManager.ExpenseAssigneeRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "ExpenseAssignee record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveExpenseAssignee(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ExpenseAssigneeRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("ExpenseAssignee", Id.ToString() );
            }
            else
            {
                _repositoryManager.ExpenseAssigneeRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "ExpenseAssignee record deleted";
            }
        }

        public async Task<string> UpdateExpenseAssignee(int? Id, ExpenseAssignee entity, CancellationToken cancellationToken = default)
        {
            if(!(Id == entity.Id))
            {
                throw new BadKeyException("ExpenseAssignee", entity.Id.ToString() , Id.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.ExpenseAssigneeRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("ExpenseAssignee", Id.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "ExpenseAssignee record updated";
        }
    }
}
