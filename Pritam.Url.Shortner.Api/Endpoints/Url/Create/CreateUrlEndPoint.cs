using HashidsNet;
using Pritam.Url.Shortner.Application.Interface;
using OriginalUrl = Pritam.Url.Shortner.Domain.Entities.Url;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Create
{

    public class CreateUrlEndPoint : BaseEndPoint<CreateUrlRequest, CreateUrlResponse>
    {
        protected IUrlCommand _urlCommand;

        public CreateUrlEndPoint(IAppDbContext dbContext, IHashids hashids, IUrlCommand urlCommand) : base(dbContext, hashids)
        {
            _urlCommand = urlCommand;
        }

        public override void Configure()
        {
            base.Configure();
            Post("/url");
            AllowAnonymous();
            Description(d => d.WithTags("Url"));
            Summary(new CreateUrlSummary());
        }

        public override async Task HandleAsync(CreateUrlRequest request, CancellationToken ct)
        {
            var id = await _urlCommand.CreateUrl(new OriginalUrl { OriginalUrl = request.Url }, ct);

            await SendAsync(new CreateUrlResponse { Id = id });
        }
    }
}
