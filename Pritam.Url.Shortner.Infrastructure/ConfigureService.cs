using Microsoft.Extensions.Configuration;
using Pritam.Url.Shortner.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Pritam.Url.Shortner.Application.Interface;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("UrlShortnerDb"); });
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            }

            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
