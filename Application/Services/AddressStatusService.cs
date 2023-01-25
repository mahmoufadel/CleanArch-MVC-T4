/////////////////////////////////////
// generated AddressStatusService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AddressStatusService : IAddressStatusService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddressStatusService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<AddressStatus> entities, string Message)> FindAddressStatus(Expression<Func<AddressStatus, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AddressStatusRepository.Find(expression);
            return (items, "AddressStatus records retrieved");
        }

        public async Task<(IEnumerable<AddressStatus> entities, string Message)> GetAllAddressStatus(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AddressStatusRepository.GetAll();
            return (items, "AddressStatus records retrieved");
        }

        public async Task<(AddressStatus? entity, string Message)> GetAddressStatusById(int? StatusId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AddressStatusRepository.GetById(StatusId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("AddressStatus", StatusId.ToString());
            }
            return (item, "AddressStatus record retrieved");
        }

        public async Task<string> AddAddressStatus(AddressStatus entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.AddressStatusRepository.GetById(entity.StatusId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("AddressStatus", entity.StatusId.ToString());
                }
                else
                {
                    await _repositoryManager.AddressStatusRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "AddressStatus record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveAddressStatus(int? StatusId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AddressStatusRepository.GetById(StatusId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("AddressStatus", StatusId.ToString());
            }
            else
            {
                _repositoryManager.AddressStatusRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "AddressStatus record deleted";
            }
        }

        public async Task<string> UpdateAddressStatus(int? StatusId, AddressStatus entity, CancellationToken cancellationToken = default)
        {
            if (!(StatusId == entity.StatusId))
            {
                throw new BadKeyException("AddressStatus", entity.StatusId.ToString(), StatusId.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.AddressStatusRepository.GetById(StatusId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("AddressStatus", StatusId.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "AddressStatus record updated";
        }
    }
}
