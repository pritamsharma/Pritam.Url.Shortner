using FastEndpoints;
using HashidsNet;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddSingleton<IHashids>(
            new Hashids(
              salt: configuration["Hashids:Salt"],
              minHashLength: 6,
              alphabet: configuration["Hashids:Alphabet"])
            );

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddFastEndpoints();

            return services;
        }
    }
}
