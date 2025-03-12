using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes;

namespace Shopping.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<T> _dbSet;
    
    public Repository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _dbSet = _applicationContext.Set<T>();
    }
    public async Task<ReadOnlyCollection<T>> GetAllAsync()
    {
        var list = await _dbSet.ToListAsync();
        return list.AsReadOnly();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
}
