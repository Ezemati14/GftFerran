using Banca.Data.SeedWork;
using Banca.Infrastructure.Context;
using Banca.Infrastructure.Modelos;
using Banca.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Banca.Data.Repository.Queries
{
    public class DepositoQuery : DepositoDataServiceBase, IDepositoQuery
    {
        public DepositoQuery(AppBancaContext context) : base(context) { }

        public async Task<double> GetSaldo(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                throw new DniNoEncontradoException();
            }

            try
            {
                //Comprobación si existe el DNI
                Deposito? depositoCliente = await ObtenerDepositoAsync(dni);
                if (depositoCliente is null)
                {
                    throw new SaldoNoEncontradoException();
                }

                return depositoCliente.Saldo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Deposito>> GetDepositos()
        {
            try
            {
                return await _context.Depositos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
