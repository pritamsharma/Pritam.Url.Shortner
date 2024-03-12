using HashidsNet;
using InMemory.Cache.Interface;
using Pritam.Url.Shortner.Application.Interface;
using Pritam.Url.Shortner.Application.Url;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUrlCommand>(provider =>
            {
                return new UrlCommand(
                    dbContext: provider.GetRequiredService<IAppDbContext>(),
                    hashids: provider.GetRequiredService<IHashids>(),
                    cache: provider.GetRequiredService<ICacheAdapter>());
            });

            return services;
        }
    }
}
