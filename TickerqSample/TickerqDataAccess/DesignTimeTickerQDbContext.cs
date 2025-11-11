using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TickerQ.Utilities.Entities;

namespace TickerqSample.TickerqDataAccess;

public class DesignTimeTickerQDbContext(DbContextOptions<DesignTimeTickerQDbContext> options) : DbContext(options)
{
    public DbSet<TimeTickerEntity> TimeTickers { get; set; }
    public DbSet<CronTickerEntity> CronTickers { get; set; }
    public DbSet<CronTickerOccurrenceEntity<CronTickerEntity>> CronTickerOccurrences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var cs = config.GetConnectionString("TickerQ");

            optionsBuilder.UseSqlServer(cs, sql =>
            {
                sql.MigrationsHistoryTable("__TickerQMigrationsHistory", "ticker");
                sql.EnableRetryOnFailure();
            });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ticker");
        
        modelBuilder.Entity<TimeTickerEntity>(entity =>
        {
            entity.ToTable("TimeTickers", "ticker");
            entity.HasKey(e => e.Id);
        });
        
        modelBuilder.Entity<CronTickerEntity>(entity =>
        {
            entity.ToTable("CronTickers", "ticker");
            entity.HasKey(e => e.Id);
        });
        
        modelBuilder.Entity<CronTickerOccurrenceEntity<CronTickerEntity>>(entity =>
        {
            entity.ToTable("CronTickerOccurrences", "ticker");
            entity.HasKey(e => e.Id);
            
            entity.HasOne(e => e.CronTicker)
                .WithMany()
                .HasForeignKey(e => e.CronTickerId);
        });
    }
}

public class DesignTimeTickerQDbContextFactory : IDesignTimeDbContextFactory<DesignTimeTickerQDbContext>
{
    public DesignTimeTickerQDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DesignTimeTickerQDbContext>();
        return new DesignTimeTickerQDbContext(optionsBuilder.Options);
    }
}