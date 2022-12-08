using Santa_Project.Data;
using Santa_Project.Data.Country;

namespace Santa_Project.IOC

{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCountryServices(this IServiceCollection services)
        {
            return services.AddSingleton<IJsonCountryRepository, JsonCountryRepository>();
        }
    }
}
