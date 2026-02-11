using RatingsApp.Models;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Services.Interfaces;

namespace RatingsApp.Services.Implementations
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(DeliveryPerformance delivery)
        {
            await _repository.AddAsync(delivery);
        }

        public async Task<DeliveryPerformance?> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }
    }
}
