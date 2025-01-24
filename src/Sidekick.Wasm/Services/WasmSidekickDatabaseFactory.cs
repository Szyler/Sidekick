using Sidekick.Common.Database;
using SqliteWasmHelper;

namespace Sidekick.Wasm.Services;

public class WasmSidekickDatabaseFactory(ISqliteWasmDbContextFactory<SidekickDbContext> factory) : ISidekickDatabaseFactory
{
    public async Task<SidekickDbContext> Create()
    {
        var context = await factory.CreateDbContextAsync();
        return context;
    }
}
