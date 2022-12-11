/////////////////////////////////////
// generated IGenericRepository.cs //
/////////////////////////////////////
using System.Linq.Expressions;

namespace Application.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        void Remove(T entitiy);
        void Update(T entitiy);
    }
}
