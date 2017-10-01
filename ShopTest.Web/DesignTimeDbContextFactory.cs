using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ShopTest.Database;

namespace ShopTest.Web
{
    public class DesignTimeDbContextFactory :IDesignTimeDbContextFactory<DatabaseContext>
    {
        /// <summary>Creates a new instance of a derived context.</summary>
        /// <param name="args"> Arguments provided by the design-time service. </param>
        /// <returns> An instance of <typeparamref name="TContext" />. </returns>
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .Build();

            builder.UseNpgsql("Host=localhost;Database=Shop;Username=postgres;Password=1",
                a => a.MigrationsAssembly("ShopTest.Web"));
            return new DatabaseContext(builder.Options);
        }
    }
}
