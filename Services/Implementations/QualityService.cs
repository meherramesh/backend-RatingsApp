using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Services.Implementations
{
    public class QualityService : IQualityService
    {
        private readonly IQualityRepository _repository;

        public QualityService(IQualityRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(QualityPerformance quality)
        {
            await _repository.AddAsync(quality);
        }

        public async Task<QualityPerformance?> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }
    }
}
