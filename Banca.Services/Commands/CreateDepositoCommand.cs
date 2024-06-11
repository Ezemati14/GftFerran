using Banca.Data.Repository.Commands;
using Banca.Domain.Enum;
using Banca.Domain.Request;
using Banca.Domain.Response;
using Banca.Services.SeedWork;
using Banca.Services.Validaciones;

namespace Banca.Services.Commands
{
    public class CreateDepositoCommand : DepositoCommandBase, ICreateDepositoCommand
    {
        public CreateDepositoCommand(IDepositoRepository depositoRepository,
                                     IValidacionService validacionService) : base(depositoRepository, validacionService)
        {
        }

        public async Task<Response> Create(SaveRequest saveRequest)
        {
            Response response = new Response { Status = StatusType.SUCCESS };

            try
            {
                //Validar DNI (Formato correcto)
                _validacionService.ValidarDNI(saveRequest.DNI);

                //Validar Importe
                _validacionService.ValidarImporte(saveRequest.Importe);

                //Guardar en BBDD
                response = await _depositoRepository.SaveAsync(saveRequest);
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
