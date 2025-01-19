using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sidekick.Database.Native;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSidekickDatabaseNative(this IServiceCollection services, string databasePath)
    {
        services.AddDbContextPool<SidekickDbContext>(o => o.UseSqlite("Data Source=" + databasePath));

        return services;
    }
}
