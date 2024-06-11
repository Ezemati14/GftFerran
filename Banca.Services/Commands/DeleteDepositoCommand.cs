using Banca.Data.Repository.Commands;
using Banca.Domain.Enum;
using Banca.Domain.Request;
using Banca.Domain.Response;
using Banca.Services.SeedWork;
using Banca.Services.Validaciones;

namespace Banca.Services.Commands
{
    public class DeleteDepositoCommand : DepositoCommandBase, IDeleteDepositoCommand
    {
        public DeleteDepositoCommand(IDepositoRepository depositoRepository,
                                     IValidacionService validacionService) : base(depositoRepository, validacionService)
        {
        }

        public async Task<Response> Delete(DeleteRequest request)
        {
            Response response = new Response() { Status = StatusType.SUCCESS };

            try
            {
                //Validar DNI (Formato correcto)
                _validacionService.ValidarDNI(request.DNI);

                //Eliminar registro
                response = await _depositoRepository.DeleteSaldo(request);
            }
            catch(Exception ex)
            {
                response.Status = StatusType.ERROR;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
