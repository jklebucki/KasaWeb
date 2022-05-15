using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class CashPointRepository : ICashPointRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public CashPointRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext ?? throw new ArgumentNullException(nameof(kasaDbContext));
        }

        public async Task<int> Add(CashPoint cashPoint)
        {
            await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, cashPoint.LocationId);
            _kasaDbContext.Add(cashPoint);
            await _kasaDbContext.SaveChangesAsync();
            return cashPoint.Id;
        }

        public async Task<CashPoint> GetById(int id)
        {
            var cashPoint = await _kasaDbContext.CashPoints.FirstOrDefaultAsync(l => l.Id == id);
            if (cashPoint == null)
                throw new Exception($"Cash point with ID {id} does not exist.");
            return cashPoint;
        }

        public async Task<IEnumerable<CashPoint>> GetLocationCashPoints(int locationId)
            => await _kasaDbContext.CashPoints.Where(c => c.LocationId == locationId).ToListAsync();

        public async Task Remove(int id)
        {
            var cashPointToRemove = await _kasaDbContext.CashPoints.FirstOrDefaultAsync(_ => _.Id == id);
            if (cashPointToRemove == null)
                throw new Exception($"Cash point with ID {id} does not exist.");
            _kasaDbContext.Remove(cashPointToRemove);
            await _kasaDbContext.SaveChangesAsync();
        }

        public async Task Update(CashPoint cashPoint)
        {
            await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, cashPoint.LocationId);
            var cashPointToUpdate = await _kasaDbContext.CashPoints.FirstOrDefaultAsync(c => c.Id == cashPoint.LocationId);
            if (cashPointToUpdate == null)
                throw new Exception($"Cash point with ID: {cashPoint.Id} does not exist.");
            try
            {
                cashPointToUpdate.Update(cashPoint.Name, cashPoint.DocumentSymbol, cashPoint.IsFifo, cashPoint.IsCurrecy, cashPoint.AccountingAccountNumber);
                _kasaDbContext.Update(cashPointToUpdate);
                await _kasaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }
    }
}
