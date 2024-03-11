using Microsoft.EntityFrameworkCore;
using Pritam.Url.Shortner.Domain.Entities;
using Pritam.Url.Shortner.Application.Interface;

namespace Rhenus.Game.Infrastructure.Persistance
{
    
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Url> Urls { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
