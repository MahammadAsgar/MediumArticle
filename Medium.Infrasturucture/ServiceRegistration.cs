using Medium.Infrasturucture.Mappings;
using Medium.Infrasturucture.Services.Entities.Abstractions;
using Medium.Infrasturucture.Services.Entities.Implementations;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Medium.Infrasturucture.Services.Users.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Medium.Infrasturucture
{
    public static class ServiceRegistration
    {
        public static void AddInfrastuructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}
