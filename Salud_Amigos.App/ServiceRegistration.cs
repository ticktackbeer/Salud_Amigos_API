using Microsoft.Extensions.DependencyInjection;
using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Service;

namespace Salud_Amigos.App
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddApp(this IServiceCollection services)
        {

            services.AddTransient<IUserAccountService, UserAccountService>();
            return services;

        }
    }
}
