using Banca.Data.SeedWork;
using Banca.Domain.Enum;
using Banca.Domain.Request;
using Banca.Domain.Response;
using Banca.Infrastructure.Context;
using Banca.Infrastructure.Modelos;

namespace Banca.Data.Repository.Commands
{
    public class DepositoRepository : DepositoDataServiceBase, IDepositoRepository
    {
        public DepositoRepository(AppBancaContext context) : base(context) { }

        public async Task<Response> SaveAsync(SaveRequest saveRequest)
        {
            _response = new Response { Status = StatusType.SUCCESS };

            try
            {
                //Comprobación si existe el DNI
                Deposito? depositoCliente = await ObtenerDepositoAsync(saveRequest.DNI);

                if (depositoCliente != null)
                {
                    depositoCliente.Saldo += saveRequest.Importe;
                    _response.Message = string.Format("El saldo del cliente {0} se ha aumentado con un importe {1}", saveRequest.DNI, saveRequest.Importe);
                }
                else
                //En caso contrario, tenemos que dar de alta el Deposito
                {
                    Deposito deposito = new Deposito();
                    deposito.DNI = saveRequest.DNI;
                    deposito.Saldo = saveRequest.Importe;

                    _context.Depositos.Add(deposito);
                    _response.Message = string.Format("Se ha dado de alta el cliente {0} con el saldo {1}", saveRequest.DNI, saveRequest.Importe);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.Status = StatusType.ERROR;
            }

            return _response;
        }

        public async Task<Response> DeleteSaldo(DeleteRequest request)
        {
            _response = new Response { Status = StatusType.SUCCESS };

            try
            {
                //Comprobación si existe el deposito por DNI
                Deposito? depositoCliente = await ObtenerDepositoAsync(request.DNI);

                if (depositoCliente is null)
                {
                    _response.Status = StatusType.ERROR;
                    _response.Message = "No se ha encontrado ningún DNI para eliminar";
                }
                else
                {
                    _context.Depositos.Remove(depositoCliente);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.Status = StatusType.ERROR;
            }

            return _response;
        }
    }
}
