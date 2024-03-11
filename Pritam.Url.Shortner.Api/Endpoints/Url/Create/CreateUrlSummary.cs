using FastEndpoints;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Create
{
    public class CreateUrlSummary : Summary<CreateUrlEndPoint>
    {
        public CreateUrlSummary()
        {
            Summary = "Create short url from provided url.";
            Description = "This endpoint will create a short url from provided url.";
            Response(500, "Internal server error.");
        }
    }
}
