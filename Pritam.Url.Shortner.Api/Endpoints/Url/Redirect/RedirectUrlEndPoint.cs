using HashidsNet;
using Pritam.Url.Shortner.Application.Interface;
using OriginalUrl = Pritam.Url.Shortner.Domain.Entities.Url;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Redirect
{

    public class RedirectUrlEndPoint : BaseEndPoint<RedirectUrlRequest>
    {
        //protected ICacheAdapter _cache;
        protected IUrlCommand _urlCommand;

        public RedirectUrlEndPoint(IAppDbContext dbContext, IHashids hashids,/* ICacheAdapter cache,*/ IUrlCommand urlCommand) : base(dbContext, hashids)
        {
            //_cache = cache;
            _urlCommand = urlCommand;
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

            //var isFromCache = false;
            //var originalUrl = await _cache.GetAsync<string>(request.Id);
            //if (string.IsNullOrEmpty(originalUrl))
            //{
            //    var url = await _dbContext.Urls.FindAsync(_hashids.DecodeSingle(request.Id), ct);
            //    originalUrl = url != null ? url.OriginalUrl : string.Empty;
            //}
            //else 
            //{
            //    isFromCache = true;
            //}

            //if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
            //{
            //    ThrowError("Url is not well formed.", 400);
            //}

            //if (!isFromCache)
            //{
            //    _ = await _cache.SetAsync(request.Id, originalUrl);
            //}

            var originalUrl = await _urlCommand.FetchUrl(request.Id, ct);

            if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
            {
                ThrowError("Url is not well formed.", 400);
            }

            await SendRedirectAsync(originalUrl, true, true);

            //await SendRedirectAsync(originalUrl, true, true);
        }
    }
}
