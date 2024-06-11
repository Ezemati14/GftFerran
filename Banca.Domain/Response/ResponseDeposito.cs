using Banca.Domain.Models.Dto;

namespace Banca.Domain.Response
{
    public class ResponseDeposito : Response
    {
        public IEnumerable<DepositoDto> Depositos { get; set; }
    }
}
