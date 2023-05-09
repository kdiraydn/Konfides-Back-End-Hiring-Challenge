using System.Linq.Expressions;
using KonfidesCase.Entities.Abstract;

namespace KonfidesCase.DataAccess.Abstract;

public interface IGenericRepository<T> where T : class, IEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteById(int id);
}