using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shopping.Infrastructure.Classes.Installers;

public static class DbInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ShoppingDbContext>(options =>
            options.UseSqlite(connectionString));

        return services;
    }
}