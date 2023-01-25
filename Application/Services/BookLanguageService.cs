/////////////////////////////////////
// generated BookLanguageService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BookLanguageService : IBookLanguageService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookLanguageService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<BookLanguage> entities, string Message)> FindBookLanguage(Expression<Func<BookLanguage, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BookLanguageRepository.Find(expression);
            return (items, "BookLanguage records retrieved");
        }

        public async Task<(IEnumerable<BookLanguage> entities, string Message)> GetAllBookLanguage(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BookLanguageRepository.GetAll();
            return (items, "BookLanguage records retrieved");
        }

        public async Task<(BookLanguage? entity, string Message)> GetBookLanguageById(int? LanguageId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BookLanguageRepository.GetById(LanguageId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("BookLanguage", LanguageId.ToString());
            }
            return (item, "BookLanguage record retrieved");
        }

        public async Task<string> AddBookLanguage(BookLanguage entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.BookLanguageRepository.GetById(entity.LanguageId);
                if (item != null)
                {
                    throw new EntityKeyFoundException("BookLanguage", entity.LanguageId.ToString());
                }
                else
                {
                    await _repositoryManager.BookLanguageRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "BookLanguage record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveBookLanguage(int? LanguageId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BookLanguageRepository.GetById(LanguageId);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("BookLanguage", LanguageId.ToString());
            }
            else
            {
                _repositoryManager.BookLanguageRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "BookLanguage record deleted";
            }
        }

        public async Task<string> UpdateBookLanguage(int? LanguageId, BookLanguage entity, CancellationToken cancellationToken = default)
        {
            if (!(LanguageId == entity.LanguageId))
            {
                throw new BadKeyException("BookLanguage", entity.LanguageId.ToString(), LanguageId.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.BookLanguageRepository.GetById(LanguageId);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("BookLanguage", LanguageId.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "BookLanguage record updated";
        }
    }
}
