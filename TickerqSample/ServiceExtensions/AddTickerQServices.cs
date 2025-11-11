using Microsoft.EntityFrameworkCore;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.Utilities.Entities;
using TickerQ.EntityFrameworkCore.DbContextFactory;
using TickerQ.EntityFrameworkCore.DependencyInjection;
using TickerqSample.BackgroundJobs;
using TickerqSample.BackgroundJobs.Base;

namespace TickerqSample.ServiceExtensions;

public static class TickerQServiceExtensions
{
    public static IServiceCollection AddTickerQServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTickerQ<TimeTickerEntity, CronTickerEntity>(options =>
        {
            options.AddDashboard(dashboardOptions =>
            {
                dashboardOptions.SetBasePath("/admin/jobs");
                dashboardOptions.WithBasicAuth("admin", "admin");
            });
            
            options.AddOperationalStore(ef =>
            {
                ef.UseTickerQDbContext<TickerQDbContext>(optionsBuilder =>
                {
                    var cs = configuration.GetConnectionString("TickerQ");
                    optionsBuilder.UseSqlServer(cs, sql =>
                    {
                        sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        sql.CommandTimeout(60);
                        sql.MigrationsHistoryTable("__TickerQMigrationsHistory", "ticker");
                    });
                });
            });
        });

        services.AddScoped<IJobRegistrationService, JobRegistrationService>();
        
        return services;
    }
}