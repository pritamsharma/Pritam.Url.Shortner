using OriginalUrl = Pritam.Url.Shortner.Domain.Entities.Url;

namespace Pritam.Url.Shortner.Application.Interface
{
    public interface IUrlCommand
    {
        Task<string> CreateUrl(OriginalUrl url, CancellationToken ct);
        Task<string> FetchUrl(string id, CancellationToken ct);
    }
}
