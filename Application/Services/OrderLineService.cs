/////////////////////////////////////
// generated OrderLineService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderLineService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<OrderLine> entities, string Message)> FindOrderLine(Expression<Func<OrderLine, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderLineRepository.Find(expression);
            return (items, "OrderLine records retrieved");
        }

        public async Task<(IEnumerable<OrderLine> entities, string Message)> GetAllOrderLine(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderLineRepository.GetAll();
            return (items, "OrderLine records retrieved");
        }

        public async Task<(OrderLine? entity, string Message)> GetOrderLineById(int? LineId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderLineRepository.GetById(LineId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("OrderLine", LineId.ToString() );
            }
            return (item, "OrderLine record retrieved");
        }

        public async Task<string> AddOrderLine(OrderLine entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.OrderLineRepository.GetById(entity.LineId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("OrderLine", entity.LineId.ToString() );
                }
                else
                {
                    await _repositoryManager.OrderLineRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "OrderLine record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveOrderLine(int? LineId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderLineRepository.GetById(LineId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("OrderLine", LineId.ToString() );
            }
            else
            {
                _repositoryManager.OrderLineRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "OrderLine record deleted";
            }
        }

        public async Task<string> UpdateOrderLine(int? LineId, OrderLine entity, CancellationToken cancellationToken = default)
        {
            if(!(LineId == entity.LineId))
            {
                throw new BadKeyException("OrderLine", entity.LineId.ToString() , LineId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.OrderLineRepository.GetById(LineId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("OrderLine", LineId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "OrderLine record updated";
        }
    }
}
