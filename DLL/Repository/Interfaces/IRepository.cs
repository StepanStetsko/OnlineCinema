using System.Linq.Expressions;

namespace DLL.Repository
{
    internal interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
