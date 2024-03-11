using FastEndpoints;
using FluentValidation;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Redirect
{
    public class ValidateRedirectUrlRequest : Validator<RedirectUrlRequest>
    {
        public ValidateRedirectUrlRequest()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Url Id is required.");
        }
    }
}
