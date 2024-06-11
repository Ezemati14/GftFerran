using Banca.Data.Repository.Commands;
using Banca.Services.Validaciones;

namespace Banca.Services.SeedWork
{
    public class DepositoCommandBase
    {
        protected readonly IDepositoRepository _depositoRepository;
        protected readonly IValidacionService _validacionService;

        public DepositoCommandBase(IDepositoRepository depositoRepository,
                                   IValidacionService validacionService)
        {
            _depositoRepository = depositoRepository;
            _validacionService = validacionService;
        }
    }
}
