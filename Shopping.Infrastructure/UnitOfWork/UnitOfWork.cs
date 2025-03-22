using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes;

namespace Shopping.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    public IGenericRepository<Item> Item {get;}
    public IGenericRepository<Category> Category { get; }
    public IGenericRepository<ShoppingList> ShoppingList { get; }

    public UnitOfWork(ApplicationContext context, IGenericRepository<Item> item, 
        IGenericRepository<Category> category, 
        IGenericRepository<ShoppingList> shoppingList)
    {
        _context = context;
        Item = item;
        Category = category;
        ShoppingList = shoppingList;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
}