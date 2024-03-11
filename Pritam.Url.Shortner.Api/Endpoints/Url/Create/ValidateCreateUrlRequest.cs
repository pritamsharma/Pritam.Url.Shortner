using FastEndpoints;
using FluentValidation;

namespace Pritam.Url.Shortner.Api.Endpoint.Url.Create
{
    public class ValidateCreateUrlRequest : Validator<CreateUrlRequest>
    {
        public ValidateCreateUrlRequest()
        {
            RuleFor(v => v.Url).NotEmpty().WithMessage("Url is required.");

            RuleFor(v => v.Url).Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute)).WithMessage("Url is not well formed.");
        }
    }
}
