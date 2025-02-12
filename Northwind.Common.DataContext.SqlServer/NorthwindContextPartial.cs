using Microsoft.EntityFrameworkCore; // to use DbContext
using Microsoft.Data.SqlClient; // to use the SqlConnectionStringBuilder
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EntityModels
{
    public partial class NorthwindContext : DbContext
    {
        private static readonly SetLastRefreshedInterceptor setLastRefreshedInterceptor = new();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder builder = new();
                builder.DataSource = ".";
                builder.InitialCatalog = "Northwind";
                builder.TrustServerCertificate = true;
                builder.MultipleActiveResultSets = true;

                // Because we want to fail fast. Default is 15 seconds
                builder.ConnectTimeout = 3;
                builder.IntegratedSecurity = true;
                optionsBuilder.UseSqlServer(builder.ConnectionString);
            }
            optionsBuilder.AddInterceptors(setLastRefreshedInterceptor);
        }
    }
}
    