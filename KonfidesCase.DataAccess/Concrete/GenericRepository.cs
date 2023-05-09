using System.Linq.Expressions;
using KonfidesCase.DataAccess.Abstract;
using KonfidesCase.DataAccess.Context;
using KonfidesCase.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KonfidesCase.DataAccess.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
{
    private readonly ApplicationContext _applicationContext;

    public GenericRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
    {
        if (filter == null)
        {
            return await _applicationContext.Set<T>().ToListAsync();
        }

        return await _applicationContext.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _applicationContext.Set<T>().FirstOrDefaultAsync(filter) ?? new T();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _applicationContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id) ?? new T();
    }

    public async Task AddAsync(T entity)
    {
        _applicationContext.Set<T>().Add(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _applicationContext.Set<T>().Update(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _applicationContext.Set<T>().Remove(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var entity = await _applicationContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _applicationContext.Set<T>().Remove(entity);
            await _applicationContext.SaveChangesAsync();
        }
    }
}