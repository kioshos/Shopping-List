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
    
    public Repository(DbContextOptions<ApplicationContext> options)
    {
        _applicationContext = new ApplicationContext(options);
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
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _applicationContext.SaveChangesAsync();
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
}
