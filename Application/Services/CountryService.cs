/////////////////////////////////////
// generated CountryService.cs //
/////////////////////////////////////
using Domain.Entities;
using Domain.Exceptions;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CountryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Country> entities, string Message)> FindCountry(Expression<Func<Country, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CountryRepository.Find(expression);
            return (items, "Country records retrieved");
        }

        public async Task<(IEnumerable<Country> entities, string Message)> GetAllCountry(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CountryRepository.GetAll();
            return (items, "Country records retrieved");
        }

        public async Task<(Country? entity, string Message)> GetCountryById(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CountryRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Country", Id.ToString());
            }
            return (item, "Country record retrieved");
        }

        public async Task<string> AddCountry(Country entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.CountryRepository.GetById(entity.Id);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Country", entity.Id.ToString());
                }
                else
                {
                    await _repositoryManager.CountryRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Country record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveCountry(int? Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CountryRepository.GetById(Id);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Country", Id.ToString());
            }
            else
            {
                _repositoryManager.CountryRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Country record deleted";
            }
        }

        public async Task<string> UpdateCountry(int? Id, Country entity, CancellationToken cancellationToken = default)
        {
            if (!(Id == entity.Id))
            {
                throw new BadKeyException("Country", entity.Id.ToString(), Id.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.CountryRepository.GetById(Id);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Country", Id.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Country record updated";
        }
    }
}
