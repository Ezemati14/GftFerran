using Banca.Domain.Request;
using Banca.Domain.Response;
using Banca.Services.Commands;
using Banca.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BancaWebApiFormacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly ICreateDepositoCommand _createDepositoCommand;
        private readonly IDeleteDepositoCommand _deleteDepositoCommand;
        private readonly IGetDepositoQuery _getDepositoQuery;

        public ClienteController(ICreateDepositoCommand createDepositoCommand,
                                 IDeleteDepositoCommand deleteDepositoCommand,
                                 IGetDepositoQuery getDepositoQuery)
        {
            _createDepositoCommand = createDepositoCommand;
            _deleteDepositoCommand = deleteDepositoCommand;
            _getDepositoQuery = getDepositoQuery; 
        }

        //Operaciones CRUD
        //C = CREATE (HttpPost) OK
        //R = READ (HttpGet) OK
        //U = UPDATE (HttpPut) --
        //D = DELETE (HttpDelete) OK

        //CREATE / UPDATE
        [HttpPost()]
        [SwaggerOperation("Guardar una transacción bancaria si no existe. En caso contrario, aumentamos el saldo de la cuenta")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response> Create(SaveRequest saveRequest)
        {
            return await _createDepositoCommand.Create(saveRequest);   
        }

        //READ
        /// <summary>
        /// Endpoint que devolverá el saldo a partir de un DNI
        /// </summary>
        /// <param name="dni">DNI a obtener el saldo</param>
        /// <returns>ResponseSaldo con el saldo</returns>
        [HttpGet("saldos/{dni}")]
        [SwaggerOperation("Obtener el saldo de una cuenta a partir de un DNI")]
        [ProducesResponseType(typeof(ResponseSaldo), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseSaldo> GetSaldo(string dni)
        {
            return await _getDepositoQuery.GetSaldo(dni);
        }

        //READ
        /// <summary>
        /// Endpoint que devolverá Obtener todos los depositos
        /// </summary>
        /// <returns>ResponseSaldo con el saldo</returns>
        [HttpGet("depositos")]
        [SwaggerOperation("Obtener todos los depositos")]
        [ProducesResponseType(typeof(ResponseDeposito), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseDeposito> GetDepositos()
        {
            return await _getDepositoQuery.GetDepositos();
        }

        //DELETE
        [HttpDelete("")]
        [SwaggerOperation("Eliminar el registro a partir de un DNI")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response> DeleteSaldo(DeleteRequest request)
        {
            return await _deleteDepositoCommand.Delete(request);
        }
    }
}
