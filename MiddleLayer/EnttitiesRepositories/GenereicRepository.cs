

using Microsoft.EntityFrameworkCore;
using MiddelLayer.APPDBCONTEXT;
using MiddelLayer.Interfaces;
using System.Linq.Expressions;

namespace MiddelLayer.EnttitiesRepositories
{
    public class GenereicRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _context;

        public GenereicRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            var query = await _context.Set<T>().ToListAsync();

            return query;
        }

        public async Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> mapping, string[] includes = null!)
        {
            IQueryable<T> query =  _context.Set<T>().Where(mapping);

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return query;
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> mapping)
        {
            IEnumerable<T> query = _context.Set<T>().Where(mapping);

            return query;
        }

        public async Task<IQueryable<T>> Paging(Expression<Func<T, bool>> mapping, int skip, int take)
        {
            IQueryable<T> query = _context.Set<T>().Where(mapping).Skip(skip).Take(take);

            return query;
        }

        public async Task<T> GetById(object id)
        {
            var search = await _context.Set<T>().FindAsync(id);

            return search;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IQueryable<T>> Filtering(Expression<Func<T, bool>> mapping,Expression<Func<T,object>> order)
        {
            var query = _context.Set<T>().Where(mapping).OrderBy(order);

            return query;
        }
    }
}
