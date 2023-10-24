namespace Ordering.Application.Models
{
    public class EmailSettings
    {
        public string FromAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string HostName { get; set; } = null!;
        public string Port { get; set; } = null!;
    }
}
