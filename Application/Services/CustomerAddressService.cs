/////////////////////////////////////
// generated CustomerAddressService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CustomerAddressService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<CustomerAddress> entities, string Message)> FindCustomerAddress(Expression<Func<CustomerAddress, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CustomerAddressRepository.Find(expression);
            return (items, "CustomerAddress records retrieved");
        }

        public async Task<(IEnumerable<CustomerAddress> entities, string Message)> GetAllCustomerAddress(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CustomerAddressRepository.GetAll();
            return (items, "CustomerAddress records retrieved");
        }

        public async Task<(CustomerAddress? entity, string Message)> GetCustomerAddressById(int? CustomerId, int? AddressId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CustomerAddressRepository.GetById(CustomerId, AddressId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("CustomerAddress", CustomerId.ToString() + '/' + AddressId.ToString());
            }
            return (item, "CustomerAddress record retrieved");
        }

        public async Task<string> AddCustomerAddress(CustomerAddress entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.CustomerAddressRepository.GetById(entity.CustomerId, entity.AddressId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("CustomerAddress", entity.CustomerId.ToString() + '/' + entity.AddressId.ToString());
                }
                else
                {
                    await _repositoryManager.CustomerAddressRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "CustomerAddress record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveCustomerAddress(int? CustomerId, int? AddressId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CustomerAddressRepository.GetById(CustomerId, AddressId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("CustomerAddress", CustomerId.ToString() + '/' + AddressId.ToString());
            }
            else
            {
                _repositoryManager.CustomerAddressRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "CustomerAddress record deleted";
            }
        }

        public async Task<string> UpdateCustomerAddress(int? CustomerId, int? AddressId, CustomerAddress entity, CancellationToken cancellationToken = default)
        {
            if (!(CustomerId == entity.CustomerId && AddressId == entity.AddressId))
            {
                throw new BadKeyException("CustomerAddress", entity.CustomerId.ToString() + '/' + entity.AddressId.ToString(), CustomerId.ToString() + '/' + AddressId.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.CustomerAddressRepository.GetById(CustomerId, AddressId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("CustomerAddress", CustomerId.ToString() + '/' + AddressId.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "CustomerAddress record updated";
        }
    }
}
