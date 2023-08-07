

using System.Linq.Expressions;

namespace MiddelLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> mapping);
        Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> mapping, string[] includes=null!);
        Task<IQueryable<T>> Paging(Expression<Func<T, bool>> mapping, int skip, int take);
        Task<IQueryable<T>> Filtering(Expression<Func<T, bool>> mapping, Expression<Func<T,object>> orderBy);
        Task<T> GetById(object id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
