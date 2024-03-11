using HashidsNet;
using Pritam.Url.Shortner.Application.Interface;
using InMemory.Cache.Interface;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Redirect
{

    public class RedirectUrlEndPoint : BaseEndPoint<RedirectUrlRequest>
    {
        protected ICacheAdapter _cache;

        public RedirectUrlEndPoint(IAppDbContext dbContext, IHashids hashids, ICacheAdapter cache) : base(dbContext, hashids)
        {
            _cache = cache;
        }

        public override void Configure()
        {
            base.Configure();
            Get("/url/{Id}");
            AllowAnonymous();
            Description(d => d.WithTags("Url"));
            Summary(new RedirectUrlSummary());
        }

        public override async Task HandleAsync(RedirectUrlRequest request, CancellationToken ct)
        {
            if (request == null)
            {
                ThrowError("Request can not be null.", 400);
            }

            var isFromCache = false;
            var originalUrl = await _cache.GetAsync<string>(request.Id);
            if (string.IsNullOrEmpty(originalUrl))
            {
                var url = await _dbContext.Urls.FindAsync(_hashids.DecodeSingle(request.Id), ct);
                originalUrl = url != null ? url.OriginalUrl : string.Empty;
            }
            else 
            {
                isFromCache = true;
            }

            if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
            {
                ThrowError("Url is not well formed.", 400);
            }

            if (!isFromCache)
            {
                _ = await _cache.SetAsync(request.Id, originalUrl);
            }
            
            await SendRedirectAsync(originalUrl, true, true);
        }
    }
}
