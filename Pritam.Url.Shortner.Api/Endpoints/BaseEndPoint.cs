using FastEndpoints;
using HashidsNet;
using Pritam.Url.Shortner.Application.Interface;

namespace Pritam.Url.Shortner.Api.Endpoint
{
    public abstract class BaseEndPoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
        where TRequest : notnull, new()
        where TResponse : notnull, new()
    {
        protected IAppDbContext _dbContext;
        protected IHashids _hashids;

        protected BaseEndPoint(IAppDbContext dbContext, IHashids hashids)
        {
            _dbContext = dbContext;
            _hashids = hashids;
        }

        public override void Configure()
        {
        }

    }

    public abstract class BaseEndPoint<TRequest> : Endpoint<TRequest>
        where TRequest : notnull, new()
    {
        protected IAppDbContext _dbContext;
        protected IHashids _hashids;

        protected BaseEndPoint(IAppDbContext dbContext, IHashids hashids)
        {
            _dbContext = dbContext;
            _hashids = hashids;
        }

        public override void Configure()
        {
        }

    }
}
