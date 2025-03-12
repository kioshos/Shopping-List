using Microsoft.EntityFrameworkCore;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes;
using Shopping.Infrastructure.Repository;

namespace Shopping.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    private Repository<Item> _itemRepository;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public Repository<Item> ItemRepository
    {
        get
        {

            if (this._itemRepository == null)
            {
                this._itemRepository = new Repository<Item>(_context);
            }
            return _itemRepository;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}