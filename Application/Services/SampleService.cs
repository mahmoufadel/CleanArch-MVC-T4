/////////////////////////////////////
// generated SampleService.cs //
/////////////////////////////////////
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Services
{
    public class SampleService : ISampleService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SampleService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<(IEnumerable<Sample> entities, string Message)> FindSample(Expression<Func<Sample, bool>> expression, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SampleRepository.Find(expression);
            return (items, "Sample records retrieved");
        }

        public async Task<(IEnumerable<Sample> entities, string Message)> GetAllSample(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SampleRepository.GetAll();
            return (items, "Sample records retrieved");
        }

        public async Task<(Sample? entity, string Message)> GetSampleById(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SampleRepository.GetById(Id1, Id2, Id3);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Sample", Id1.ToString() + '/' + Id2.ToString() + '/' + Id3.ToString());
            }
            return (item, "Sample record retrieved");
        }

        public async Task<string> AddSample(Sample entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                var item = await _repositoryManager.SampleRepository.GetById(entity.Id1, entity.Id2, entity.Id3);
                if (item != null)
                {
                    throw new EntityKeyFoundException("Sample", entity.Id1.ToString() + '/' + entity.Id2.ToString() + '/' + entity.Id3.ToString());
                }
                else
                {
                    await _repositoryManager.SampleRepository.Add(entity);
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    return "Sample record added";
                }
            }
            throw new Exception("Add Error");
        }

        public async Task<string> RemoveSample(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SampleRepository.GetById(Id1, Id2, Id3);
            if (item == null)
            {
                throw new EntityKeyNotFoundException("Sample", Id1.ToString() + '/' + Id2.ToString() + '/' + Id3.ToString());
            }
            else
            {
                _repositoryManager.SampleRepository.Remove(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return "Sample record deleted";
            }
        }

        public async Task<string> UpdateSample(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3, Sample entity, CancellationToken cancellationToken = default)
        {
            if (!(Id1 == entity.Id1 && Id2 == entity.Id2 && Id3 == entity.Id3))
            {
                throw new BadKeyException("Sample", entity.Id1.ToString() + '/' + entity.Id2.ToString() + '/' + entity.Id3.ToString(), Id1.ToString() + '/' + Id2.ToString() + '/' + Id3.ToString());
            }

            _repositoryManager.UnitOfWork.GetContext().Entry(entity).State = EntityState.Modified;

            try
            {
                _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _repositoryManager.SampleRepository.GetById(Id1, Id2, Id3);
                if (item == null)
                {
                    throw new EntityKeyNotFoundException("Sample", Id1.ToString() + '/' + Id2.ToString() + '/' + Id3.ToString());
                }
                else
                {
                    throw new Exception("Update Error");
                }
            }
            return "Sample record updated";
        }
    }
}
