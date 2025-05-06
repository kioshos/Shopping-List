using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes;

namespace Shopping.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ShoppingDbContext _shoppingDbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ShoppingDbContext shoppingDbContext)
    {
        _shoppingDbContext = shoppingDbContext;
        this._dbSet = _shoppingDbContext.Set<T>();
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
