namespace Sidekick.Common.Database;

public interface ISidekickDatabaseFactory
{
    Task<SidekickDbContext> Create();
}
