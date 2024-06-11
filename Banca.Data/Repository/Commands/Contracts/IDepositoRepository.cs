using Banca.Domain.Request;
using Banca.Domain.Response;

namespace Banca.Data.Repository.Commands
{
    public interface IDepositoRepository
    {
        Task<Response> DeleteSaldo(DeleteRequest request);
        Task<Response> SaveAsync(SaveRequest saveRequest);
    }
}