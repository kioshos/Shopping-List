using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Item> Item { get; }
    IGenericRepository<Category> Category { get; }
    IGenericRepository<ShoppingList> ShoppingList { get; }
    Task SaveChangesAsync();
}