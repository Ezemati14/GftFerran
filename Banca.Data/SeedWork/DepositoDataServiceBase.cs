using Banca.Domain.Enum;
using Banca.Domain.Response;
using Banca.Infrastructure.Context;
using Banca.Infrastructure.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Banca.Data.SeedWork
{
    public class DepositoDataServiceBase
    {
        protected Response _response = new Response() { Status = StatusType.SUCCESS };
        protected ResponseSaldo _responseSaldo = new ResponseSaldo() { Status = StatusType.SUCCESS };
        protected readonly AppBancaContext _context;

        public DepositoDataServiceBase(AppBancaContext context)
        {
            _context = context;
        }

        protected async Task<Deposito?> ObtenerDepositoAsync(string dni)
        {
             return await _context.Depositos.FirstOrDefaultAsync(x => x.DNI.ToUpper().Equals(dni.ToUpper()));
        }
    }
}
