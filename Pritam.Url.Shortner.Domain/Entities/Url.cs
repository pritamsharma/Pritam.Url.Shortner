using Pritam.Url.Shortner.Domain.Common;

namespace Pritam.Url.Shortner.Domain.Entities
{
    public class Url : BaseEntity
    {

        public string OriginalUrl { get; set; } = default!;

    }
}
