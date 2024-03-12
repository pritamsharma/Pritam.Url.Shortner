using HashidsNet;
using InMemory.Cache.Interface;
using Pritam.Url.Shortner.Application.Interface;
using OriginalUrl = Pritam.Url.Shortner.Domain.Entities.Url;

namespace Pritam.Url.Shortner.Application.Url
{
    public class UrlCommand : IUrlCommand
    {

        protected IAppDbContext _dbContext;
        protected IHashids _hashids;
        protected ICacheAdapter _cache;

        public UrlCommand(IAppDbContext dbContext, IHashids hashids, ICacheAdapter cache)
        {
            _dbContext = dbContext;
            _hashids = hashids;
            _cache = cache;
        }

        public async Task<string> CreateUrl(OriginalUrl url, CancellationToken ct)
        {
            _dbContext.Urls.Add(url);
            _ = await _dbContext.SaveChangesAsync(ct);
            return _hashids.Encode(url.Id);
        }

        public async Task<string> FetchUrl(string id, CancellationToken ct)
        {
            var isFromCache = false;
            var originalUrl = await _cache.GetAsync<string>(id);
            if (string.IsNullOrEmpty(originalUrl))
            {
                var url = await _dbContext.Urls.FindAsync(_hashids.DecodeSingle(id), ct);
                originalUrl = url != null ? url.OriginalUrl : string.Empty;
            }
            else
            {
                isFromCache = true;
            }

            if (!isFromCache)
            {
                _ = await _cache.SetAsync(id, originalUrl);
            }

            return originalUrl;
        }

    }
}
