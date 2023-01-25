/////////////////////////////////////
// generated CustomerService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CustomerService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Customer> entities, string Message)> FindCustomer(Expression<Func<Customer, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CustomerRepository.Find(expression);
            return (items, "Customer records retrieved");
        }

        public async Task<(IEnumerable<Customer> entities, string Message)> GetAllCustomer(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CustomerRepository.GetAll();
            return (items, "Customer records retrieved");
        }

        public async Task<(Customer? entity, string Message)> GetCustomerById(int? CustomerId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CustomerRepository.GetById(CustomerId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Customer", CustomerId.ToString());
            }
            return (item, "Customer record retrieved");
        }

        public async Task<string> AddCustomer(Customer entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.CustomerRepository.GetById(entity.CustomerId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Customer", entity.CustomerId.ToString());
                }
                else
                {
                    await _repositoryManager.CustomerRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Customer record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveCustomer(int? CustomerId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CustomerRepository.GetById(CustomerId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Customer", CustomerId.ToString());
            }
            else
            {
                _repositoryManager.CustomerRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Customer record deleted";
            }
        }

        public async Task<string> UpdateCustomer(int? CustomerId, Customer entity, CancellationToken cancellationToken = default)
        {
            if (!(CustomerId == entity.CustomerId))
            {
                throw new BadKeyException("Customer", entity.CustomerId.ToString(), CustomerId.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.CustomerRepository.GetById(CustomerId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Customer", CustomerId.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Customer record updated";
        }
    }
}
