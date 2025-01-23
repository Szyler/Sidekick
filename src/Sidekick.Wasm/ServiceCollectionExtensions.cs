using Microsoft.EntityFrameworkCore;
using Sidekick.Common.Database;
using SqliteWasmHelper;

namespace Sidekick.Wasm;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSidekickDatabaseWasm(this IServiceCollection services)
    {
        services.AddSqliteWasmDbContextFactory<SidekickDbContext>(
            opts => opts.UseSqlite("Data Source=Sidekick.sqlite3"));

        return services;
    }
}
