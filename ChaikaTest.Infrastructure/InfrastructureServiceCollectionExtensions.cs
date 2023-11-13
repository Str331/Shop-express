using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChaikaTest.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public const string DEFAULT_DATABASE_CONNECTIONSTRING = @"Data Source=(Localdb)\MSSQLLocalDB; Initial Catalog=Consult;Integrated Security=True";
        public const string DEFAULT_DATABASE_PROVIDER = "sqlserver";

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddTransient<IMD5ChecksumService, MD5ChecksumService>();

            var connStr = _config.GetConnectionString("ConnectionString");

            // take the connection string from the environment variable or use hard-coded database name
            var connectionString = connStr ??
                                   DEFAULT_DATABASE_CONNECTIONSTRING;

            // take the database provider from the environment variable or use hard-coded database provider
            var databaseProvider = _config.GetConnectionString("ASPNETCORE_Conduit_DatabaseProvider");
            if (string.IsNullOrWhiteSpace(databaseProvider))
            {
                databaseProvider = DEFAULT_DATABASE_PROVIDER;
            }

            services.AddDbContext<Context>(options =>
            {
                if (databaseProvider.ToLower().Trim().Equals("sqlite"))
                {
                    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
                }
                else if (databaseProvider.ToLower().Trim().Equals("sqlserver"))
                {
                    // only works in windows container
                    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
                }
                else
                {
                    throw new Exception("Database provider unknown. Please check configuration");
                }
            });
        }
    }
}
