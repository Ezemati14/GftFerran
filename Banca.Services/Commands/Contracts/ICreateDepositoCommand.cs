using Banca.Domain.Request;
using Banca.Domain.Response;

namespace Banca.Services.Commands
{
    public interface ICreateDepositoCommand
    {
        Task<Response> Create(SaveRequest saveRequest);
    }
}