using FastEndpoints;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Redirect
{
    public class RedirectUrlSummary : Summary<RedirectUrlEndPoint>
    {
        public RedirectUrlSummary()
        {
            Summary = "Authencates a layer.";
            Description = "This endpoint will authenticate a player.";
            Response(500, "Internal server error.");
        }
    }
}
