using Santa_Project.Data.Country;
using Santa_Project.Data;
using Santa_Project.Data.Reindeer;

namespace Santa_Project.IOC.Reindeer
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddReindeerServices(this IServiceCollection services)
        {
            return services.AddSingleton<IJsonReindeerRepository, JsonReindeerRepository>();
        }
    }
}
