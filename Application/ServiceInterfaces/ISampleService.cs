//////////////////////////////////////
// generated ISampleService.cs //
//////////////////////////////////////
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.ServiceInterfaces
{
    public interface ISampleService
    {
        Task<string> AddSample(Sample entity, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Sample> entities, string Message)> FindSample(Expression<Func<Sample, bool>> expression, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Sample> entities, string Message)> GetAllSample(CancellationToken cancellationToken = default);
        Task<(Sample? entity, string Message)> GetSampleById(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3, CancellationToken cancellationToken = default);
        Task<string> RemoveSample(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3, CancellationToken cancellationToken = default);
        Task<string> UpdateSample(System.Int32? Id1, System.Int32? Id2, System.Int32? Id3, Sample entity, CancellationToken cancellationToken = default);
    }
}
