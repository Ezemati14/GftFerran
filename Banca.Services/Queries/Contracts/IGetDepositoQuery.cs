using Banca.Domain.Response;

namespace Banca.Services.Queries
{
    public interface IGetDepositoQuery
    {
        Task<ResponseSaldo> GetSaldo(string dni);
        Task<ResponseDeposito> GetDepositos();
    }
}