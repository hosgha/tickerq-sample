// File: DesignTimeTickerQDbContextFactory.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TickerQ.EntityFrameworkCore.DbContextFactory;

namespace TickerqSample;

public class TickerQDbContextFactory : IDesignTimeDbContextFactory<TickerQDbContext>
{
    public TickerQDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TickerQDbContext>();
        var cs = config.GetConnectionString("TickerQ");

        optionsBuilder.UseSqlServer(cs, sql =>
        {
            sql.MigrationsHistoryTable("__TickerQMigrationsHistory", "ticker");
            sql.EnableRetryOnFailure();
        });

        return new TickerQDbContext(optionsBuilder.Options);
    }
}