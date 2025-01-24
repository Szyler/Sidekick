using Microsoft.EntityFrameworkCore;
using Sidekick.Common.Database;
using Sidekick.Wasm.Services;
using SqliteWasmHelper;

namespace Sidekick.Wasm;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSidekickDatabaseWasm(this IServiceCollection services)
    {
        services.AddSqliteWasmDbContextFactory<SidekickDbContext>(opts => opts.UseSqlite("Data Source=Sidekick.sqlite3"));

        services.AddSingleton<ISidekickDatabaseFactory, WasmSidekickDatabaseFactory>();

        return services;
    }
}
