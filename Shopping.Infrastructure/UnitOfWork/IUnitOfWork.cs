using Shopping.Application.Interfaces;

namespace Shopping.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}