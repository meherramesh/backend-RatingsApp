using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Services.Implementations
{
    public class OverallService : IOverallService
    {
        private readonly IOverallRepository _repository;

        public OverallService(IOverallRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(OverallRating overall)
        {
            await _repository.AddAsync(overall);
        }

        public async Task<OverallRating?> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }
    }
}
