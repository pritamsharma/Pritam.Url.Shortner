using Microsoft.EntityFrameworkCore;

namespace Pritam.Url.Shortner.Application.Interface
{
    public interface IAppDbContext
    {
        DbSet<Pritam.Url.Shortner.Domain.Entities.Url> Urls { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
