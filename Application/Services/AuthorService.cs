/////////////////////////////////////
// generated AuthorService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AuthorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Author> entities, string Message)> FindAuthor(Expression<Func<Author, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AuthorRepository.Find(expression);
            return (items, "Author records retrieved");
        }

        public async Task<(IEnumerable<Author> entities, string Message)> GetAllAuthor(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AuthorRepository.GetAll();
            return (items, "Author records retrieved");
        }

        public async Task<(Author? entity, string Message)> GetAuthorById(int? AuthorId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AuthorRepository.GetById(AuthorId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Author", AuthorId.ToString() );
            }
            return (item, "Author record retrieved");
        }

        public async Task<string> AddAuthor(Author entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.AuthorRepository.GetById(entity.AuthorId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Author", entity.AuthorId.ToString() );
                }
                else
                {
                    await _repositoryManager.AuthorRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Author record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveAuthor(int? AuthorId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AuthorRepository.GetById(AuthorId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Author", AuthorId.ToString() );
            }
            else
            {
                _repositoryManager.AuthorRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Author record deleted";
            }
        }

        public async Task<string> UpdateAuthor(int? AuthorId, Author entity, CancellationToken cancellationToken = default)
        {
            if(!(AuthorId == entity.AuthorId))
            {
                throw new BadKeyException("Author", entity.AuthorId.ToString() , AuthorId.ToString() );
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            { 
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.AuthorRepository.GetById(AuthorId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Author", AuthorId.ToString() );
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Author record updated";
        }
    }
}
