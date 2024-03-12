using FastEndpoints;
using HashidsNet;
//using InMemory.Cache.Redis;
using InMemory.Cache.Memcached;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.AddSingleton(
                new RedisAdapterFactory(
                    configuration: configuration["Redis:Connection"] ?? string.Empty,
                    expiryTimeSeconds: Convert.ToInt32(configuration["Redis:ExpiryTime"])).CreateCacheAdapter());*/

            services.AddSingleton(
                new MemcachedAdapterFactory(
                    address: configuration["Memcached:Address"] ?? string.Empty,
                    port: Convert.ToInt32(configuration["Memcached:Port"] ?? string.Empty),
                    expiryTimeSeconds: Convert.ToInt32(configuration["Memcached:ExpiryTime"])).CreateCacheAdapter());

            services.AddSingleton<IHashids>(
                new Hashids(
                  salt: configuration["Hashids:Salt"],
                  minHashLength: 6,
                  alphabet: configuration["Hashids:Alphabet"]));

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
