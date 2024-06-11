using Banca.Domain.Enum;

namespace Banca.Domain.Response
{
    public class Response
    {
        public StatusType Status { get; set; }
        public string? Message { get; set; }
    }
}
