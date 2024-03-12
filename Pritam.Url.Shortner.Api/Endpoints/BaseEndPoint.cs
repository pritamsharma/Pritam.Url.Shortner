using FastEndpoints;
using Pritam.Url.Shortner.Application.Interface;

namespace Pritam.Url.Shortner.Api.Endpoint
{
    public abstract class BaseEndPoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
        where TRequest : notnull, new()
        where TResponse : notnull, new()
    {
        protected IUrlCommand _urlCommand;

        protected BaseEndPoint(IUrlCommand urlCommand)
        {
            _urlCommand = urlCommand;
        }

        public override void Configure()
        {
        }

    }

    public abstract class BaseEndPoint<TRequest> : Endpoint<TRequest>
        where TRequest : notnull, new()
    {
        protected IUrlCommand _urlCommand;

        protected BaseEndPoint(IUrlCommand urlCommand)
        {
            _urlCommand = urlCommand;
        }

        public override void Configure()
        {
        }

    }
}
