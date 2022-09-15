using Salud_Amigos.App;
using Salud_Amigos.Storage;

namespace Salud_Amigos.Api
{
    public static class ServiceCollectionExtentions
    {

        public static void AddProjectDependencies(this IServiceCollection services)
        {
            services.AddStorage();
            services.AddApp();
        }

        public static void AddConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile("secrets.json", optional: true, reloadOnChange: false);
        }

    }
}
