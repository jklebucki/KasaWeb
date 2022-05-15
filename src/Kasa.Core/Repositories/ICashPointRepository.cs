
using Kasa.Core.Domain;

namespace Kasa.Core.Repositories
{
    public interface ICashPointRepository
    {
        Task<int> Add(CashPoint cashPoint);
        Task Remove(int id);
        Task Update(CashPoint cashPoint);
        Task<CashPoint> GetById(int id);
        Task<IEnumerable<CashPoint>> GetLocationCashPoints(int locationId);
    }
}

