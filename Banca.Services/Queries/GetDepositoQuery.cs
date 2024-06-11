using AutoMapper;
using Banca.Data.Repository.Queries;
using Banca.Domain.Enum;
using Banca.Domain.Models.Dto;
using Banca.Domain.Response;
using Banca.Infrastructure.Modelos;
using Banca.Services.SeedWork;

namespace Banca.Services.Queries
{
    public class GetDepositoQuery : DepositoQueryBase, IGetDepositoQuery
    {
        public readonly IMapper _mapper;

        public GetDepositoQuery(IMapper mapper, IDepositoQuery depositoQuery) : base(depositoQuery)
        { 
            _mapper = mapper;
        }

        public async Task<ResponseDeposito> GetDepositos()
        {
            ResponseDeposito response = new ResponseDeposito() { Status = StatusType.SUCCESS };

            try
            {
                //Obtener desde BBDD
                IEnumerable<Deposito> depositosDb = await _depositoQuery.GetDepositos();

                response.Depositos = _mapper.Map<IEnumerable<DepositoDto>>(depositosDb);
            }
            catch (Exception ex)
            {
                response.Status = StatusType.ERROR;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseSaldo> GetSaldo(string dni)
        {
            ResponseSaldo response = new ResponseSaldo() { Status = StatusType.SUCCESS } ;

            try
            {
                //Obtener desde BBDD
                response.Saldo = await _depositoQuery.GetSaldo(dni);
            }
            catch (Exception ex)
            {
                response.Status = StatusType.ERROR;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
