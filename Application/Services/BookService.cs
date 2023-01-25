/////////////////////////////////////
// generated BookService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Book> entities, string Message)> FindBook(Expression<Func<Book, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BookRepository.Find(expression);
            return (items, "Book records retrieved");
        }

        public async Task<(IEnumerable<Book> entities, string Message)> GetAllBook(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BookRepository.GetAll(); return (items, "Book records retrieved");
        }

        public async Task<(Book? entity, string Message)> GetBookById(int? BookId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BookRepository.GetById(BookId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Book", BookId.ToString());
            }
            return (item, "Book record retrieved");
        }

        public async Task<string> AddBook(Book entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.BookRepository.GetById(entity.BookId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Book", entity.BookId.ToString());
                }
                else
                {
                    await _repositoryManager.BookRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Book record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveBook(int? BookId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BookRepository.GetById(BookId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Book", BookId.ToString());
            }
            else
            {
                _repositoryManager.BookRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Book record deleted";
            }
        }

        public async Task<string> UpdateBook(int? BookId, Book entity, CancellationToken cancellationToken = default)
        {
            if (!(BookId == entity.BookId))
            {
                throw new BadKeyException("Book", entity.BookId.ToString(), BookId.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.BookRepository.GetById(BookId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Book", BookId.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Book record updated";






        }
    }
}
