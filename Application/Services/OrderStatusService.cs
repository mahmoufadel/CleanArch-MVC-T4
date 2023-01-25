/////////////////////////////////////
// generated OrderStatusService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderStatusService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<OrderStatus> entities, string Message)> FindOrderStatus(Expression<Func<OrderStatus, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderStatusRepository.Find(expression);
            return (items, "OrderStatus records retrieved");
        }

        public async Task<(IEnumerable<OrderStatus> entities, string Message)> GetAllOrderStatus(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderStatusRepository.GetAll();
            return (items, "OrderStatus records retrieved");
        }

        public async Task<(OrderStatus? entity, string Message)> GetOrderStatusById(int? StatusId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderStatusRepository.GetById(StatusId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("OrderStatus", StatusId.ToString());
            }
            return (item, "OrderStatus record retrieved");
        }

        public async Task<string> AddOrderStatus(OrderStatus entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.OrderStatusRepository.GetById(entity.StatusId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("OrderStatus", entity.StatusId.ToString());
                }
                else
                {
                    await _repositoryManager.OrderStatusRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "OrderStatus record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveOrderStatus(int? StatusId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderStatusRepository.GetById(StatusId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("OrderStatus", StatusId.ToString());
            }
            else
            {
                _repositoryManager.OrderStatusRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "OrderStatus record deleted";
            }
        }

        public async Task<string> UpdateOrderStatus(int? StatusId, OrderStatus entity, CancellationToken cancellationToken = default)
        {
            if (!(StatusId == entity.StatusId))
            {
                throw new BadKeyException("OrderStatus", entity.StatusId.ToString(), StatusId.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.OrderStatusRepository.GetById(StatusId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("OrderStatus", StatusId.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "OrderStatus record updated";
        }
    }
}
