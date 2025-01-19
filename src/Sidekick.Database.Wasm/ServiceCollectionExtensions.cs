using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sidekick.Database.Wasm;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSidekickDatabaseWasm(this IServiceCollection services)
    {
        services.AddDbContextFactory<SidekickDbContext>(options => options.UseSqlite("Filename=Sidekick.db"));

        return services;
    }
}
