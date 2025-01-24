using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sidekick.Common.Database;
using Sidekick.Common.Native.Services;

namespace Sidekick.Common.Native;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSidekickCommonNative(this IServiceCollection services, string databasePath)
    {
        services.AddDbContextPool<SidekickDbContext>(o => o.UseSqlite("Data Source=" + databasePath));

        services.AddSingleton<ISidekickDatabaseFactory, NativeSidekickDatabaseFactory>();

        return services;
    }
}
