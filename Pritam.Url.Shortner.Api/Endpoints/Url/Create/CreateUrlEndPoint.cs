using HashidsNet;
using Pritam.Url.Shortner.Application.Interface;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Create
{

    public class CreateUrlEndPoint : BaseEndPoint<CreateUrlRequest, CreateUrlResponse>
    {

        public CreateUrlEndPoint(IAppDbContext dbContext, IHashids hashids) : base(dbContext, hashids)
        {
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
            if (request == null)
            {
                ThrowError("Request can not be null.", 400);
            }

            var url = new Domain.Entities.Url { OriginalUrl = request.Url };

            _dbContext.Urls.Add(url);
            _ = await _dbContext.SaveChangesAsync(ct);

            await SendAsync(new CreateUrlResponse { Id = _hashids.Encode(url.Id) });
        }
    }
}
