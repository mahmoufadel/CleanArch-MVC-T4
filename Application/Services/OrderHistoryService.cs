/////////////////////////////////////
// generated OrderHistoryService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderHistoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<OrderHistory> entities, string Message)> FindOrderHistory(Expression<Func<OrderHistory, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderHistoryRepository.Find(expression);
            return (items, "OrderHistory records retrieved");
        }

        public async Task<(IEnumerable<OrderHistory> entities, string Message)> GetAllOrderHistory(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderHistoryRepository.GetAll();
            return (items, "OrderHistory records retrieved");
        }

        public async Task<(OrderHistory? entity, string Message)> GetOrderHistoryById(int? HistoryId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderHistoryRepository.GetById(HistoryId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("OrderHistory", HistoryId.ToString() );
            }
            return (item, "OrderHistory record retrieved");
        }

        public async Task<string> AddOrderHistory(OrderHistory entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.OrderHistoryRepository.GetById(entity.HistoryId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("OrderHistory", entity.HistoryId.ToString() );
                }
                else
                {
                    await _repositoryManager.OrderHistoryRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "OrderHistory record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveOrderHistory(int? HistoryId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderHistoryRepository.GetById(HistoryId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("OrderHistory", HistoryId.ToString() );
            }
            else
            {
                _repositoryManager.OrderHistoryRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "OrderHistory record deleted";
            }
        }

        public async Task<string> UpdateOrderHistory(int? HistoryId, OrderHistory entity, CancellationToken cancellationToken = default)
        {
            if(!(HistoryId == entity.HistoryId))
            {
                throw new BadKeyException("OrderHistory", entity.HistoryId.ToString() , HistoryId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.OrderHistoryRepository.GetById(HistoryId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("OrderHistory", HistoryId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "OrderHistory record updated";
        }
    }
}
