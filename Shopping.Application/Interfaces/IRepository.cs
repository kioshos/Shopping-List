﻿using System.Collections.ObjectModel;

namespace Shopping.Application.Interfaces;

public interface IRepository<T>
{
    Task<ReadOnlyCollection<T>> GetAllAsync();
    
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
}