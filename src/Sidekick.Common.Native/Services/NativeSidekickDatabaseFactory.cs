using Microsoft.EntityFrameworkCore;
using Sidekick.Common.Database;

namespace Sidekick.Common.Native.Services;

public class NativeSidekickDatabaseFactory(DbContextOptions<SidekickDbContext> options) : ISidekickDatabaseFactory
{
    public Task<SidekickDbContext> Create()
    {
        var dbContext = new SidekickDbContext(options);
        return Task.FromResult(dbContext);
    }
}
