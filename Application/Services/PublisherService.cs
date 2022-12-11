/////////////////////////////////////
// generated PublisherService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PublisherService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Publisher> entities, string Message)> FindPublisher(Expression<Func<Publisher, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.PublisherRepository.Find(expression);
            return (items, "Publisher records retrieved");
        }

        public async Task<(IEnumerable<Publisher> entities, string Message)> GetAllPublisher(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.PublisherRepository.GetAll();
            return (items, "Publisher records retrieved");
        }

        public async Task<(Publisher? entity, string Message)> GetPublisherById(int? PublisherId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.PublisherRepository.GetById(PublisherId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Publisher", PublisherId.ToString() );
            }
            return (item, "Publisher record retrieved");
        }

        public async Task<string> AddPublisher(Publisher entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.PublisherRepository.GetById(entity.PublisherId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Publisher", entity.PublisherId.ToString() );
                }
                else
                {
                    await _repositoryManager.PublisherRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Publisher record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemovePublisher(int? PublisherId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.PublisherRepository.GetById(PublisherId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Publisher", PublisherId.ToString() );
            }
            else
            {
                _repositoryManager.PublisherRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Publisher record deleted";
            }
        }

        public async Task<string> UpdatePublisher(int? PublisherId, Publisher entity, CancellationToken cancellationToken = default)
        {
            if(!(PublisherId == entity.PublisherId))
            {
                throw new BadKeyException("Publisher", entity.PublisherId.ToString() , PublisherId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.PublisherRepository.GetById(PublisherId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Publisher", PublisherId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Publisher record updated";
        }
    }
}
