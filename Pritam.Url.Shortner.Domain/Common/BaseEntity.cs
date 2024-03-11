namespace Pritam.Url.Shortner.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
