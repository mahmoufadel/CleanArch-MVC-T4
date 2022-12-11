/////////////////////////////////////
// generated CustOrderService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CustOrderService : ICustOrderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CustOrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<CustOrder> entities, string Message)> FindCustOrder(Expression<Func<CustOrder, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CustOrderRepository.Find(expression);
            return (items, "CustOrder records retrieved");
        }

        public async Task<(IEnumerable<CustOrder> entities, string Message)> GetAllCustOrder(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CustOrderRepository.GetAll();
            return (items, "CustOrder records retrieved");
        }

        public async Task<(CustOrder? entity, string Message)> GetCustOrderById(int? OrderId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CustOrderRepository.GetById(OrderId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("CustOrder", OrderId.ToString() );
            }
            return (item, "CustOrder record retrieved");
        }

        public async Task<string> AddCustOrder(CustOrder entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.CustOrderRepository.GetById(entity.OrderId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("CustOrder", entity.OrderId.ToString() );
                }
                else
                {
                    await _repositoryManager.CustOrderRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "CustOrder record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveCustOrder(int? OrderId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CustOrderRepository.GetById(OrderId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("CustOrder", OrderId.ToString() );
            }
            else
            {
                _repositoryManager.CustOrderRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "CustOrder record deleted";
            }
        }

        public async Task<string> UpdateCustOrder(int? OrderId, CustOrder entity, CancellationToken cancellationToken = default)
        {
            if(!(OrderId == entity.OrderId))
            {
                throw new BadKeyException("CustOrder", entity.OrderId.ToString() , OrderId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.CustOrderRepository.GetById(OrderId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("CustOrder", OrderId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "CustOrder record updated";
        }
    }
}
