using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder
using Microsoft.EntityFrameworkCore; // To use UseSqlServer
using Microsoft.Extensions.DependencyInjection; // To use IServiceCollection


namespace Northwind.EntityModels;

public static class NorthWindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer Database provider.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="connectionString">Set to override the default</param> 
    /// <returns>An IServiceCollection that can be used to add more services</returns>
    public static IServiceCollection AddNorthwindcontext(this IServiceCollection services, string? connectionString = null)
    {
        if (connectionString is null) 
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = ".";
            builder.InitialCatalog = "Northwind";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;
            builder.ConnectTimeout = 3; // To fail fast
            builder.IntegratedSecurity = true; // Because we are using integrated security

            connectionString = builder.ConnectionString;
        }
        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer(connectionString);
            //Log to console when executing EF Core Commands
            options.LogTo(Console.WriteLine,
                new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        },
        // Register with a transient lifetime to avoid concurrency issues with Blazor Server projects.
        contextLifetime: ServiceLifetime.Transient,
        optionsLifetime: ServiceLifetime.Transient);

        return services;
    }
}



