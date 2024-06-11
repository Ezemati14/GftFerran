using Banca.Domain.Request;
using Banca.Domain.Response;

namespace Banca.Services.Commands
{
    public interface IDeleteDepositoCommand
    {
        Task<Response> Delete(DeleteRequest request);
    }
}