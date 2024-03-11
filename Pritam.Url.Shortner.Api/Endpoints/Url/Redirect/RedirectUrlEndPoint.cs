using HashidsNet;
using Pritam.Url.Shortner.Application.Interface;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Redirect
{

    public class RedirectUrlEndPoint : BaseEndPoint<RedirectUrlRequest>
    {

        public RedirectUrlEndPoint(IAppDbContext dbContext, IHashids hashids) : base(dbContext, hashids)
        {
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

            var urlId = _hashids.DecodeSingle(request.Id);

            var url = await _dbContext.Urls.FindAsync(urlId);

            if (url == null || !Uri.IsWellFormedUriString(url.OriginalUrl, UriKind.Absolute))
            {
                ThrowError("Url is not well formed.", 400);
            }

            await SendRedirectAsync(url.OriginalUrl, true, true);
        }
    }
}
