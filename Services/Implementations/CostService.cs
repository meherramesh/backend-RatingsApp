using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RatingsApp.Services.Implementations
{
    public class CostService : ICostService
    {
        private readonly ICostRepository _repository;

        public CostService(ICostRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CostReduction cost)
        {
            await _repository.AddAsync(cost);
        }

        public async Task<CostReduction?> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }
    }
}
