using Banca.Data.Repository.Queries;

namespace Banca.Services.SeedWork
{
    public class DepositoQueryBase
    {
        protected readonly IDepositoQuery _depositoQuery;

        public DepositoQueryBase(IDepositoQuery depositoQuery)
        {
            _depositoQuery = depositoQuery;
        }
    }
}
