/////////////////////////////////////
// generated AddressService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddressService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Address> entities, string Message)> FindAddress(Expression<Func<Address, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AddressRepository.Find(expression);
            return (items, "Address records retrieved");
        }

        public async Task<(IEnumerable<Address> entities, string Message)> GetAllAddress(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AddressRepository.GetAll();
            return (items, "Address records retrieved");
        }

        public async Task<(Address? entity, string Message)> GetAddressById(int? AddressId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AddressRepository.GetById(AddressId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Address", AddressId.ToString() );
            }
            return (item, "Address record retrieved");
        }

        public async Task<string> AddAddress(Address entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.AddressRepository.GetById(entity.AddressId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Address", entity.AddressId.ToString() );
                }
                else
                {
                    await _repositoryManager.AddressRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Address record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveAddress(int? AddressId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AddressRepository.GetById(AddressId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Address", AddressId.ToString() );
            }
            else
            {
                _repositoryManager.AddressRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Address record deleted";
            }
        }

        public async Task<string> UpdateAddress(int? AddressId, Address entity, CancellationToken cancellationToken = default)
        {
            if(!(AddressId == entity.AddressId))
            {
                throw new BadKeyException("Address", entity.AddressId.ToString() , AddressId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.AddressRepository.GetById(AddressId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Address", AddressId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Address record updated";
        }
    }
}
