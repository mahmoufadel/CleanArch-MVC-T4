////////////////////////////////////
// generated GenericRepository.cs //
////////////////////////////////////
using Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //replace DbContex with ApplicationDbContext
        public ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
