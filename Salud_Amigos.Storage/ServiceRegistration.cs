using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Salud_Amigos.App.Interface;

namespace Salud_Amigos.Storage
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddStorage(this IServiceCollection services)
        {

            return services
                .AddDbContext<SqlContext>(ConfigureSqlServer)
                .AddScoped<IRepository, Repository>();

        }

        private static void ConfigureSqlServer(IServiceProvider serviceProvider, DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("Db");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
