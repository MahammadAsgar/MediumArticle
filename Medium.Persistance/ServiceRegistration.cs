using Medium.Persistance.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Medium.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
