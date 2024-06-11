using Banca.Infrastructure.Modelos;

namespace Banca.Data.Repository.Queries
{
    public interface IDepositoQuery
    {
        Task<double> GetSaldo(string dni);
        Task<IEnumerable<Deposito>> GetDepositos();
    }
}