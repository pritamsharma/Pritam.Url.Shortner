using Pritam.Url.Shortner.Application.Interface;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Redirect
{

    public class RedirectUrlEndPoint : BaseEndPoint<RedirectUrlRequest>
    {

        public RedirectUrlEndPoint(IUrlCommand urlCommand) : base(urlCommand)
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
            var originalUrl = await _urlCommand.FetchUrl(request.Id, ct);

            await SendRedirectAsync(originalUrl, true, true);
        }
    }
}
