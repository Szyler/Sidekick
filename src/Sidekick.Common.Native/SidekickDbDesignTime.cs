using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sidekick.Common.Database;

namespace Sidekick.Common.Native;

internal class SidekickDbDesignTime : IDesignTimeDbContextFactory<SidekickDbContext>
{
    public SidekickDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SidekickDbContext>();
        builder.UseSqlite("Filename=sidekick.db");
        return new SidekickDbContext(builder.Options);
    }
}
